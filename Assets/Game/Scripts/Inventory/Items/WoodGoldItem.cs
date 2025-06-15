using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodGoldItem : InventoryItem
{
    public override string ItemName()
    {
        return "Goldwood";
    }

    public override string ItemDescription()
    {
        return "Wood with... golden balls in it? Very heavy, solid and shiny.";
    }

    public override Sprite ItemIcon()
    {
        return Resources.Load<Sprite>("Sprites/wood_gold");
    }

    public override ItemType Type()
    {
        return ItemType.GoldWood;
    }

    public override void Use(GameObject player)
    {
    }
}
