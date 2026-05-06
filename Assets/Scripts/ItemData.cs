using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Crafting/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Basic Info")]
    public string itemName = "Item";
    public Sprite icon; // Иконка для UI (опционально)

    [Header("Stack Limit")]
    public int maxStack = 64; // Максимальное количество в одном слоте
}