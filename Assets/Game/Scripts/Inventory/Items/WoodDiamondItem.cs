using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDiamondItem : InventoryItem
{
    public override string ItemName()
    {
        return "Diawood";
    }

    public override string ItemDescription()
    {
        return "Very shiny and strong.";
    }

    public override Sprite ItemIcon()
    {
        return Resources.Load<Sprite>("Sprites/wood_dia");
    }

    public override ItemType Type()
    {
        return ItemType.DiamondWood;
    }

    public override bool IsConsumed()
    {
        return false;
    }

    public override void Use(GameObject player)
    {
    }
}
