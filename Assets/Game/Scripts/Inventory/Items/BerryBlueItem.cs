using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryBlueItem : InventoryItem
{
    public override string ItemName()
    {
        return "Blueberry";
    }

    public override string ItemDescription()
    {
        return "Yum-yum.";
    }

    public override Sprite ItemIcon()
    {
        return Resources.Load<Sprite>("Sprites/BerryBlue");
    }

    public override ItemType Type()
    {
        return ItemType.BlueBerry;
    }

    public override void Use(GameObject player)
    {
    }
}
