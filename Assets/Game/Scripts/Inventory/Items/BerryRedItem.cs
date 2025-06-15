using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryRedItem : InventoryItem
{
    public override string ItemName()
    {
        return "Redberry";
    }

    public override string ItemDescription()
    {
        return "Abstract red berry which you can't recognize no matter how hard you try. Strawberry?";
    }

    public override Sprite ItemIcon()
    {
        return Resources.Load<Sprite>("Sprites/BerryRed");
    }

    public override ItemType Type()
    {
        return ItemType.RedBerry;
    }

    public override bool IsConsumed()
    {
        return false;
    }

    public override void Use(GameObject player)
    {
    }
}
