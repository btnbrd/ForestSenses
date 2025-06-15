using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLightItem : InventoryItem
{
    public override string ItemName()
    {
        return "Light potion";
    }

    public override string ItemDescription()
    {
        return "Blue liquid that makes your lantern shine brighter upon drinking.";
    }

    public override Sprite ItemIcon()
    {
        return Resources.Load<Sprite>("Sprites/PotionBlue");
    }

    public override ItemType Type()
    {
        return ItemType.LightPotion;
    }

    public override void Use(GameObject player)
    {
    }
}
