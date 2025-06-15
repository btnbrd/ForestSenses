using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpeedItem : InventoryItem
{
    public override string ItemName()
    {
        return "Speed potion";
    }

    public override string ItemDescription()
    {
        return "A bottle of some red liquid, doesn't look too tasty, but makes your legs really work.";
    }

    public override Sprite ItemIcon()
    {
        return Resources.Load<Sprite>("Sprites/PotionRed");
    }

    public override ItemType Type()
    {
        return ItemType.SpeedPotion;
    }

    public override void Use(GameObject player)
    {
    }
}
