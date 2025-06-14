using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum InventoryItemType
{
    None
};

[System.Serializable]
class InventoryData
{
    public List<InventoryItem> items;
}

// Как юзать: вешаешь на невидимый геймобджект в каждой сцене где нужен инвентарь, всем пользователям (другим скриптам то етсь) раздаёшь ссылку на этот инвентарь.
public class InventoryManager : MonoBehaviour
{
    const String INVENTORY_PLAYERPREF_NAME = "Inventory";

    public Dictionary<InventoryItemType, List<InventoryItem>> items;

    void Awake()
    {
        var data = JsonUtility.FromJson<InventoryData>(PlayerPrefs.GetString(INVENTORY_PLAYERPREF_NAME));
        foreach (var item in data.items)
        {
            if (!items.ContainsKey(item.ItemType))
            {
                items[item.ItemType] = new List<InventoryItem>();
            }
            items[item.ItemType].Add(item);
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
