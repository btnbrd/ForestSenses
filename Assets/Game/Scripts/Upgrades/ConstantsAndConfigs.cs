using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CraftingRecipe
{
    public CraftingRecipe(List<Tuple<ItemType, int>> inputItems, ItemType outputItem)
    {
        input = inputItems;
        output = outputItem;
    }

    public List<Tuple<ItemType, int>> input;
    public ItemType output;
}

public class ConstantsAndConfigs
{
    public const String MIN_RADIUS_STAT_NAME = "MinRadius";
    public const String MAX_RADIUS_STAT_NAME = "MaxRadius";
    public const String SPEED_STAT_NAME = "Speed";

    public const float MIN_RADIUS_DEFAULT = 4.0f;
    public const float MAX_RADIUS_DEFAULT = 5.0f;
    public const float SPEED_MULTIPLIER_DEFAULT = 1.0f;

    public const float UPGRADE_EXPONENTIAL_MULTIPLIER = 1.1f;

    public static List<CraftingRecipe> ConsumablesCraftingRecipes = 
    new List<CraftingRecipe>
    {
        new CraftingRecipe(
            new List<Tuple<ItemType, int>>{
                new Tuple<ItemType, int>(ItemType.Berry, 1)
            },
            ItemType.Mushroom
        ),
        new CraftingRecipe(
            new List<Tuple<ItemType, int>>{
                new Tuple<ItemType, int>(ItemType.Berry, 3)
            },
            ItemType.Berry
        )
    };

    public static List<CraftingRecipe> ToolsCraftingRecipes =
    new List<CraftingRecipe>
    {
        new CraftingRecipe(
            new List<Tuple<ItemType, int>>{
                new Tuple<ItemType, int>(ItemType.Berry, 4),
                new Tuple<ItemType, int>(ItemType.Mushroom, 5)
            },
            ItemType.Mushroom
        )
    };

    public static List<CraftingRecipe> UpgradesCraftingRecipes =
    new List<CraftingRecipe>
    {
        new CraftingRecipe(
            new List<Tuple<ItemType, int>>{
                new Tuple<ItemType, int>(ItemType.Mushroom, 20)
            },
            ItemType.Berry
        )
    };
}


