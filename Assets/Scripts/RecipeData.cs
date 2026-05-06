using UnityEngine;
using System;

[Serializable]
public class Ingredient
{
    public ItemData item;
    public int amount;
}

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Crafting/RecipeData")]
public class RecipeData : ScriptableObject
{
    public string recipeName = "Recipe";
    public Ingredient[] ingredients;
    public ItemData result;
    public int resultAmount = 1;
}