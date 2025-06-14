using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomItem : InventoryItem
{
    public override string ItemName()
    {
        return "Mushroom";
    }

    public override string ItemDescription()
    {
        return "Mushroom. Used for craft. Really just a clever mushroom. Just kidding! Stupid as hell, can't even solve quadratic equations.";
    }

    public override Sprite ItemIcon()
    {
        return Resources.Load<Sprite>("Sprites/PretendThisIsMushroom");
    }

    public override ItemType Type()
    {
        return ItemType.Mushroom;
    }

    public override void Use(GameObject player)
    {
    }
}
