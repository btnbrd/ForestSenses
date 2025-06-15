using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomRedItem : InventoryItem
{
    public override string ItemName()
    {
        return "Redshroom";
    }

    public override string ItemDescription()
    {
        return "A red mushroom. Looks hateful.";
    }

    public override Sprite ItemIcon()
    {
        return Resources.Load<Sprite>("Sprites/ShroomRed");
    }

    public override ItemType Type()
    {
        return ItemType.RedMushroom;
    }

    public override void Use(GameObject player)
    {
    }
}
