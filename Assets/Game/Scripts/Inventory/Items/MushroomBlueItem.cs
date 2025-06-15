using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBlueItem : InventoryItem
{
    public override string ItemName()
    {
        return "Blueroom";
    }

    public override string ItemDescription()
    {
        return "A blue mushroom. Looks like it's full of curiousity.";
    }

    public override Sprite ItemIcon()
    {
        return Resources.Load<Sprite>("Sprites/ShroomBlue");
    }

    public override ItemType Type()
    {
        return ItemType.BlueMushroom;
    }

    public override bool IsConsumed()
    {
        return false;
    }

    public override void Use(GameObject player)
    {
    }
}
