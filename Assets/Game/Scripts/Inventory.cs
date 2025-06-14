using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

[DefaultExecutionOrder((-1))]
public class Inventory : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public static Inventory Instance { get; private set; }
    // [SerializeField] private int mushrooms = 0;
    // [SerializeField] private int berries = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void CollectWithMouse(ItemType itemType)
    {
        // switch (itemType)
        // {
        //     case ItemType.Berry:
        //         berries += 1;
        //         break;
        //     case ItemType.Mushroom:
        //         mushrooms += 1;
        //         break;
        //     default:
        //         throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null);
        // }
        // Debug.Log(mushrooms);

        switch (itemType)
        {
            case ItemType.Berry:
                inventoryManager.items[ItemType.Berry].Add(new BlackberryItem());
                inventoryManager.Save();
                Debug.Log("Get a berry.");
                Debug.Log(PlayerPrefs.GetString("Inventory"));
                break;
            case ItemType.Mushroom:
                inventoryManager.items[ItemType.Mushroom].Add(new MushroomItem());
                inventoryManager.Save();
                Debug.Log("Get a mushroom.");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null);
        }
    }
    
    public static InventoryItem CreateItem(ItemType t)
    {
        switch (t)
        {
            case ItemType.Berry:
                return new BlackberryItem();
            case ItemType.Mushroom:
                return new MushroomItem();
            default:
                throw new InvalidOperationException("unknown item type you are trying to create!");
        }
    }
}