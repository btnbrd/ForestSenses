using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackberryItem : InventoryItem
{
    public override string ItemName()
    {
        return "Blackberry";
    }

    public override string ItemDescription()
    {
        return "Blackberry. Used for craft. Really just a stupid berry, I hate it.";
    }

    public override Sprite ItemIcon()
    {
        return Resources.Load<Sprite>("Sprites/Berry");
    }

    public override ItemType Type()
    {
        return ItemType.Berry;
    }

    public override void Use(GameObject player)
    {
        // var light = player.GetComponent<PlayerRefToLightController>().lightController;

        // light.ApplyBoost(10f, 10f);
    }
}
