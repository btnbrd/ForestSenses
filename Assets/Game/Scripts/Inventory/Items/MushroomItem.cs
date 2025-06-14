using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomItem : InventoryItem
{
    public override string ItemName()
    {
        return "Mushroom";
    }

    public override Sprite ItemIcon()
    {
        throw new System.NotImplementedException();
    }

    public override ItemType Type()
    {
        return ItemType.Mushroom;
    }

    public override void Use(GameObject player)
    {
    }
}
