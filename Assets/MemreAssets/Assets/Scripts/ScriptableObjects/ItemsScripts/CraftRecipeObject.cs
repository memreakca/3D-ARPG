using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Inventory System/Crafting/Recipe")]
public class CraftRecipeObject : ScriptableObject
{
    public string Name;
    public Sprite uiDisplay;
    public Item result;
    public Ingredient[] ingredients;
    public InventoryObject inventoryObject;

    public bool CanCraft()
    {
        foreach (Ingredient ingredient in ingredients)
        {
            
            bool containsCurrentIngredient = inventoryObject.ContainsItem(ingredient.item, ingredient.amount);
          
            if (!containsCurrentIngredient)
            {
                return false;
            }
        }
        return true;
    }

    private void RemoveIngredientsFromInventory()
    {
        foreach (Ingredient ingredient in ingredients)
        {
            inventoryObject.RemoveAmount(ingredient.item, ingredient.amount);
            
        }
    }
    public void Craft()
    {
        if (CanCraft())
        {
            RemoveIngredientsFromInventory();

            inventoryObject.AddItem(result, 1);
            Debug.Log("You Crafted a : " + result.Name);
            CraftingEvents.ItemCrafted(result);
        }
        else Debug.Log("You Dont Have Enough Ingredients");
    }
}
[System.Serializable]
public class Ingredient
{
    public Item item;
    public int amount;
}                                                                                                                                                                            