using UnityEngine;
using UnityEngine.UI;

public class ShopItemButton : MonoBehaviour
{
    public Image normalImage; // Image normale
    public Image darkImage;   // Image sombre
    public int itemIndex; 
    private bool isSelected = false; 

    void Start()
    {
        UpdateVisualState();
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        var manager = ShopItemManager.Instance;
        if (manager == null)
        {
            Debug.LogError("ShopItemManager instance is missing in this scene!");
            return;
        }

        int selectedCount = CountSelectedItems(manager);

        if (isSelected)
        {
            // Désélectionner l'item
            isSelected = false;
            manager.SetItemState(itemIndex, false);
        }
        else
        {
            // Vérifier si on peut encore sélectionner
            if (selectedCount < 2)
            {
                isSelected = true;
                manager.SetItemState(itemIndex, true);
            }
            else
            {
                // Maximum atteint
                Debug.Log("Vous ne pouvez sélectionner que 2 items.");
                return;
            }
        }

        UpdateVisualState();
    }

    void UpdateVisualState()
    {
        if (isSelected)
        {
            normalImage.gameObject.SetActive(true);
            darkImage.gameObject.SetActive(false);
        }
        else
        {
            normalImage.gameObject.SetActive(false);
            darkImage.gameObject.SetActive(true);
        }
    }

    private int CountSelectedItems(ShopItemManager manager)
    {
        int count = 0;
        for (int i = 0; i < manager.selectedItems.Length; i++)
        {
            if (manager.selectedItems[i]) count++;
        }
        return count;
    }
}
