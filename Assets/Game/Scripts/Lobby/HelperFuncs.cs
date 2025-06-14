using System;
using System.Collections.Generic;
using System.Linq;

public class HelperFuncs
{

    public static bool IsListContainedInDictionary(List<Tuple<ItemType, int>> itemList, 
                                        Dictionary<ItemType, List<InventoryItem>> dictionary)
    {
        foreach (var (itemType, requiredCount) in itemList)
        {
            // Check if dictionary has this item type at all
            if (!dictionary.TryGetValue(itemType, out var bucket))
                return false;

            // Check if bucket has enough items of this type
            if (bucket.Count < requiredCount)
                return false;
        }
        return true;
    }

    public static bool IsListContainedInDictionary(List<InventoryItem> itemList,
                                       Dictionary<ItemType, List<InventoryItem>> dictionary)
    {
        // First group the items in the list by their type (like the dictionary does)
        var groupedList = itemList
            .GroupBy(item => item.Type())
            .ToDictionary(
                group => group.Key,
                group => group.ToList()
            );

        // Check each group
        foreach (var kvp in groupedList)
        {
            // If dictionary doesn't contain this item type at all
            if (!dictionary.TryGetValue(kvp.Key, out var bucket))
                return false;

            // If the bucket doesn't contain all items of this type
            if (!ContainsAllItems(bucket, kvp.Value))
                return false;
        }

        return true;
    }

    // Helper to check if one list contains all items from another (with counts)
    private static bool ContainsAllItems(List<InventoryItem> bucket, List<InventoryItem> desiredItems)
    {
        // Make a temporary copy to track remaining items
        var remainingItems = new List<InventoryItem>(bucket);
        
        foreach (var item in desiredItems)
        {
            if (!remainingItems.Remove(item))
                return false;
        }
        
        return true;
    }
}
