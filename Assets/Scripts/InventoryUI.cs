using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("References")]
    public Inventory inventory;
    public GameObject slotPrefab;
    public Transform slotContainer;

    [Header("Optional: Toggle Panel")]
    public GameObject inventoryPanel;

    void Start()
    {
        if (inventory != null)
        {
            inventory.OnInventoryChanged += RefreshUI;
        }
        RefreshUI();

        // Скрываем инвентарь при старте (опционально)
        if (inventoryPanel != null)
            inventoryPanel.SetActive(false);
    }

    public void ToggleInventory()
    {
        if (inventoryPanel != null)
        {
            bool isActive = inventoryPanel.activeSelf;
            inventoryPanel.SetActive(!isActive);

            if (!isActive)
                RefreshUI(); // Обновляем при открытии
        }
    }

    public void ShowInventory()
    {
        if (inventoryPanel != null)
            inventoryPanel.SetActive(true);
    }

    public void HideInventory()
    {
        if (inventoryPanel != null)
            inventoryPanel.SetActive(false);
    }

    void RefreshUI()
    {
        // Защита от пустых ссылок
        if (slotContainer == null || slotPrefab == null || inventory == null)
        {
            Debug.LogWarning("InventoryUI: Не назначены ссылки в Inspector!");
            return;
        }

        // Очищаем старые слоты
        foreach (Transform child in slotContainer)
            Destroy(child.gameObject);

        // Создаём новые слоты
        foreach (var slot in inventory.slots)
        {
            if (slot.item == null) continue;

            GameObject slotObj = Instantiate(slotPrefab, slotContainer);

            // Ищем Image для иконки
            Transform iconTransform = slotObj.transform.Find("IconImage");
            Image iconImg = iconTransform != null ? iconTransform.GetComponent<Image>() : null;

            if (iconImg != null && slot.item.icon != null)
            {
                iconImg.sprite = slot.item.icon;
                iconImg.enabled = true;
                iconImg.color = Color.white; 
            }
            else if (iconImg != null)
            {
                // Если у предмета нет иконки — скрываем Image
                iconImg.enabled = false;
            }
            else
            {
                Debug.LogWarning($"В префабе слота не найден объект 'IconImage' с компонентом Image!");
            }

            //Ищем Text для количества по имени
            Transform textTransform = slotObj.transform.Find("AmountText");
            Text amountText = textTransform != null ? textTransform.GetComponent<Text>() : null;

            if (amountText != null)
            {
                amountText.text = slot.amount.ToString();
            }
            else
            {
                Debug.LogWarning($"В префабе слота не найден объект 'AmountText' с компонентом Text!");
            }
        }
    }
}