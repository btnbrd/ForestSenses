using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
class InventoryData
{
    public List<InventoryItem> items = new List<InventoryItem>();
}

// Как юзать: вешаешь на невидимый геймобджект в каждой сцене где нужен инвентарь, всем пользователям (другим скриптам то етсь) раздаёшь ссылку на этот инвентарь.
public class InventoryManager : MonoBehaviour
{
    const String INVENTORY_PLAYERPREF_NAME = "Inventory";

    public Dictionary<ItemType, List<InventoryItem>> items = new Dictionary<ItemType, List<InventoryItem>>();

    void Awake()
    {
        foreach (ItemType itemType in (ItemType[])Enum.GetValues(typeof(ItemType)))
        {
            items[itemType] = new List<InventoryItem>();
        }

        var data = JsonUtility.FromJson<InventoryData>(PlayerPrefs.GetString(INVENTORY_PLAYERPREF_NAME));
        if (data is null)
        {
            data = new InventoryData();
        }

        foreach (var item in data.items)
        {
            items[item.Type()].Add(item);
        }
    }

    public void Save()
    {
        InventoryData data = new InventoryData();
        foreach (var kv in items)
        {
            foreach (var item in kv.Value)
            {
                data.items.Add(item);
            }
        }

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(INVENTORY_PLAYERPREF_NAME, json);
        PlayerPrefs.Save();
    }
}
