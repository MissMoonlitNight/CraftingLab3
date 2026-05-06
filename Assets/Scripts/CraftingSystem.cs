using UnityEngine;
using System.Collections.Generic;

public class CraftingSystem : MonoBehaviour
{
    public Inventory playerInventory;
    public List<RecipeData> availableRecipes; // все рецепты

    public bool CanCraft(RecipeData recipe)
    {
        foreach (var ing in recipe.ingredients)
        {
            if (!playerInventory.HasItem(ing.item, ing.amount))
                return false;
        }
        return true;
    }

    public void Craft(RecipeData recipe)
    {
        if (!CanCraft(recipe)) return;

        // списываем ингредиенты
        foreach (var ing in recipe.ingredients)
        {
            playerInventory.RemoveItem(ing.item, ing.amount);
        }

        // добавляем результат
        playerInventory.AddItem(recipe.result, recipe.resultAmount);
    }
}