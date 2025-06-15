using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    RedBerry,
    BlueBerry,
    RedMushroom,
    BlueMushroom,
    OrdinaryWood,
    GoldWood,
    DiamondWood,
    SpeedPotion,
    LightPotion,
    IronAxe,
    Lantern,
    Compass,
    Key
}

public class CollectableWithMouse : MonoBehaviour
{
    [SerializeField] private ItemType itemType = ItemType.RedMushroom;
    
    private void Awake()
    {
    }

    private void OnMouseDown()
    {
        Inventory.Instance.CollectWithMouse(itemType); 
        // renderer.materials[OUTLINE_ID].;
        gameObject.SetActive(false);
    }
}