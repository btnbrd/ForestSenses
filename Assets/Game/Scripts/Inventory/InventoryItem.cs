using UnityEngine;


[System.Serializable]
public abstract class InventoryItem
{
    private string itemName;
    private Sprite icon;
    public virtual InventoryItemType ItemType => InventoryItemType.None;

    public string ItemName => itemName;
    public Sprite Icon => icon;

    // Called when the item is used/consumed
    public abstract void Use(GameObject player);
}