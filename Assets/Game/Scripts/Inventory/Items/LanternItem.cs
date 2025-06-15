using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternItem : InventoryItem
{
    public override string ItemName()
    {
        return "Lantern";
    }

    public override string ItemDescription()
    {
        return "A bright light source to aid your own.";
    }

    public override Sprite ItemIcon()
    {
        return Resources.Load<Sprite>("Sprites/Lantern");
    }

    public override ItemType Type()
    {
        return ItemType.Lantern;
    }

    public override void Use(GameObject player)
    {
    }
}
