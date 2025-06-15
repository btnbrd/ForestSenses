using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : InventoryItem
{
    public override string ItemName()
    {
        return "Key";
    }

    public override string ItemDescription()
    {
        return "???";
    }

    public override Sprite ItemIcon()
    {
        return Resources.Load<Sprite>("Sprites/Key");
    }

    public override ItemType Type()
    {
        return ItemType.Key;
    }

    public override void Use(GameObject player)
    {
    }
}
