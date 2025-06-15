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
        inventoryManager.items[itemType].Add(CreateItem(itemType));
        inventoryManager.Save();
    }
    
    public static InventoryItem CreateItem(ItemType t)
    {
        switch (t)
        {
            case ItemType.RedBerry:
                return new BerryRedItem();
            case ItemType.BlueBerry:
                return new BerryBlueItem();
            case ItemType.RedMushroom:
                return new MushroomRedItem();
            case ItemType.BlueMushroom:
                return new MushroomBlueItem();
            case ItemType.OrdinaryWood:
                return new WoodOrdinaryItem();
            case ItemType.GoldWood:
                return new WoodGoldItem();
            case ItemType.DiamondWood:
                return new WoodDiamondItem();
            case ItemType.SpeedPotion:
                return new PotionSpeedItem();
            case ItemType.LightPotion:
                return new PotionLightItem();
            case ItemType.IronAxe:
                return new AxeIronItem();
            case ItemType.Lantern:
                return new LanternItem();
            case ItemType.Compass:
                return new CompassItem();
            case ItemType.Key:
                return new KeyItem();
            default:
                throw new ArgumentOutOfRangeException(nameof(t), t, null);
        }
    }
}