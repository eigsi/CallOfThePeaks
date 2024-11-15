
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButton : MonoBehaviour
{
    public Image normalImage; // Image pour la version normale
    public Image darkImage;   // Image pour la version sombre
    private bool isSelected = false; // État de sélection
    private static int selectedItemCount = 0; // Compteur d'items sélectionnés
    private static int maxSelectedItems = 2;  // Nombre maximal d'items sélectionnés

    void Start()
    {
        UpdateVisualState();
        // Ajouter un listener pour le clic sur le bouton
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        if (isSelected)
        {
            // Désélectionner l'item
            isSelected = false;
            selectedItemCount--;
        }
        else
        {
            if (selectedItemCount < maxSelectedItems)
            {
                // Sélectionner l'item
                isSelected = true;
                selectedItemCount++;
            }
            else
            {
                // Ne rien faire ou afficher un message indiquant que le maximum est atteint
                Debug.Log("Vous ne pouvez sélectionner que " + maxSelectedItems + " items.");
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
}
