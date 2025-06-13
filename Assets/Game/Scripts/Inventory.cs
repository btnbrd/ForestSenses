using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

[DefaultExecutionOrder((-1))]
public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    [SerializeField] private int mushrooms = 0;
    [SerializeField] private int berries = 0;
    
    private void Awake()
    {
        Instance = this;
    }

    public void CollectWithMouse(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Berry:
                berries += 1;
                break;
            case ItemType.Mushroom:
                mushrooms += 1;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null);
        }
        Debug.Log(mushrooms);
    }
}