using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassItem : InventoryItem
{
    public override string ItemName()
    {
        return "Compass";
    }

    public override string ItemDescription()
    {
        return "Where does it lead?";
    }

    public override Sprite ItemIcon()
    {
        return Resources.Load<Sprite>("Sprites/compass");
    }

    public override ItemType Type()
    {
        return ItemType.Compass;
    }

    public override void Use(GameObject player)
    {
    }
}
