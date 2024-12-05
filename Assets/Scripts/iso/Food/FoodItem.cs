using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public float foodValue = 10f; // Valeur nutritionnelle
    public GameObject replacementPrefab; // Le prefab qui remplace l'item après collecte

    public void ReplaceItem()
    {
        if (replacementPrefab != null)
        {
            // Instancie le remplacement à la position actuelle
            Instantiate(replacementPrefab, transform.position, transform.rotation);

            // Détruit l'ancien item (cet objet)
            Destroy(gameObject);
        }
    }
}
