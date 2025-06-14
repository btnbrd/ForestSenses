using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Berry,
    Mushroom
}

public class CollectableWithMouse : MonoBehaviour
{
    [SerializeField] private ItemType itemType = ItemType.Mushroom;
    private Renderer renderer;
    
    private void Awake()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        Inventory.Instance.CollectWithMouse(itemType); 
        // renderer.materials[OUTLINE_ID].;
        gameObject.SetActive(false);
    }
}