using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hotbar : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject itemSpritePrefab;
    [SerializeField] private Transform itemsContainer;
    [SerializeField] private float spacing = 100f;
    [SerializeField] private float updateInterval = 1f;

    private Dictionary<ItemType, GameObject> activeItems = new Dictionary<ItemType, GameObject>();
    private Queue<GameObject> pooledObjects = new Queue<GameObject>();
    private Dictionary<ItemType, List<InventoryItem>> lastKnownInventory;

    private void Start()
    {
        // Initialize object pool with some items
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(itemSpritePrefab, itemsContainer);
            obj.SetActive(false);
            pooledObjects.Enqueue(obj);
        }

        StartCoroutine(InventoryCheckRoutine());
    }

    private IEnumerator InventoryCheckRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(updateInterval);
            
            // Only repopulate if inventory changed
            if (HasInventoryChanged())
            {
                Repopulate();
            }
        }
    }

    private bool HasInventoryChanged()
    {
        var currentInventory = Inventory.Instance.inventoryManager.items;
        
        // First check if counts differ
        if (lastKnownInventory == null || currentInventory.Count != lastKnownInventory.Count)
            return true;

        // Then check each bucket
        foreach (var kvp in currentInventory)
        {
            if (!lastKnownInventory.TryGetValue(kvp.Key, out var oldList) || 
                oldList.Count != kvp.Value.Count)
            {
                return true;
            }
        }

        return false;
    }

    public void Repopulate()
    {
        ClearItems();
        lastKnownInventory = new Dictionary<ItemType, List<InventoryItem>>();

        float xPos = 0f;
        foreach (var kv in Inventory.Instance.inventoryManager.items)
        {
            // Cache the inventory state for change detection
            lastKnownInventory[kv.Key] = new List<InventoryItem>(kv.Value);

            if (kv.Value.Count > 0)
            {
                // Get or create UI element
                GameObject itemUI = GetPooledObject();
                itemUI.transform.localPosition = new Vector3(xPos, 0, 0);
                xPos += spacing;

                // Set up visuals
                Image img = itemUI.GetComponent<Image>();
                img.sprite = kv.Value[0].ItemIcon();
                img.enabled = true;

                // Set up quantity text
                var textProvider = itemUI.GetComponent<ItemIconQuantityTextProvider>();
                textProvider.GetText().text = kv.Value.Count.ToString();

                var button = itemUI.GetComponent<Button>();
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    Inventory.Instance.inventoryManager.items[kv.Key][0].Use(player);
                    if (Inventory.Instance.inventoryManager.items[kv.Key][0].IsConsumed())
                    {
                        Inventory.Instance.inventoryManager.items[kv.Key].RemoveAt(0);
                        Inventory.Instance.inventoryManager.Save();
                    }
                    Repopulate();
                });

                itemUI.SetActive(true);
                activeItems[kv.Key] = itemUI;
            }
        }
    }

    private GameObject GetPooledObject()
    {
        if (pooledObjects.Count > 0)
        {
            return pooledObjects.Dequeue();
        }
        
        // Create new object if pool is empty
        GameObject obj = Instantiate(itemSpritePrefab, itemsContainer);
        return obj;
    }

    private void ClearItems()
    {
        foreach (var kv in activeItems)
        {
            kv.Value.SetActive(false);
            pooledObjects.Enqueue(kv.Value);
        }
        activeItems.Clear();
    }
}