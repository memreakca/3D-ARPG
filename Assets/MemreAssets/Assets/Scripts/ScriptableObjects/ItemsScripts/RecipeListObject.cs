using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Recipe List",menuName = "Inventory System/Crafting/RecipeList")]
public class RecipeListObject : ScriptableObject
{
    public List<CraftRecipeObject> recipeList;


} 

