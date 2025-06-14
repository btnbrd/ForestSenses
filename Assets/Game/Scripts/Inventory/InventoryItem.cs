using UnityEngine;


[System.Serializable]
public abstract class InventoryItem
{
    public abstract string ItemName();
    public abstract Sprite ItemIcon();
    public abstract ItemType Type();

    // Called when the item is used/consumed
    public abstract void Use(GameObject player);
}