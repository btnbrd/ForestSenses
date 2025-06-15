using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodOrdinaryItem : InventoryItem
{
    public override string ItemName()
    {
        return "Wood";
    }

    public override string ItemDescription()
    {
        return "Ordinary wood. Pretty solid and smells good.";
    }

    public override Sprite ItemIcon()
    {
        return Resources.Load<Sprite>("Sprites/wood_ord");
    }

    public override ItemType Type()
    {
        return ItemType.OrdinaryWood;
    }

    public override void Use(GameObject player)
    {
    }
}
