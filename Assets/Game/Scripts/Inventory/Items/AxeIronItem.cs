using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeIronItem : InventoryItem
{
    public override string ItemName()
    {
        return "Iron axe";
    }

    public override string ItemDescription()
    {
        return "A heavy tool to help chopping trees down.";
    }

    public override Sprite ItemIcon()
    {
        return Resources.Load<Sprite>("Sprites/AxeIron");
    }

    public override ItemType Type()
    {
        return ItemType.IronAxe;
    }

    public override bool IsConsumed()
    {
        return false;
    }

    public override void Use(GameObject player)
    {
    }
}
