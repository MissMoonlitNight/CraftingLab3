using UnityEngine;
using UnityEngine.UI;

public class CraftingUI : MonoBehaviour
{
    public CraftingSystem craftingSystem;
    public GameObject recipeButtonPrefab;
    public Transform buttonContainer;

    void Start()
    {
        foreach (var recipe in craftingSystem.availableRecipes)
        {
            GameObject btnObj = Instantiate(recipeButtonPrefab, buttonContainer);
            btnObj.GetComponentInChildren<Text>().text = recipe.recipeName;

            Button btn = btnObj.GetComponent<Button>();
            btn.onClick.AddListener(() => craftingSystem.Craft(recipe));
        }
    }
}