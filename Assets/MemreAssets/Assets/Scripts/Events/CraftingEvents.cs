using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingEvents : MonoBehaviour
{
    public delegate void ItemCraftedEventHandler(Item item);
    public static event ItemCraftedEventHandler OnItemCrafted;

    public static void ItemCrafted(Item item)
    {
        if (OnItemCrafted != null)
            OnItemCrafted(item);
    }
}
