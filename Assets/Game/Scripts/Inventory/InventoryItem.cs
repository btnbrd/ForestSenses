using UnityEngine;


[System.Serializable]
public abstract class InventoryItem
{
    public abstract string ItemName();
    public abstract string ItemDescription();
    public abstract Sprite ItemIcon();
    public abstract ItemType Type();
    public abstract bool IsConsumed();

    // Called when the item is used/consumed
    public abstract void Use(GameObject player);
}