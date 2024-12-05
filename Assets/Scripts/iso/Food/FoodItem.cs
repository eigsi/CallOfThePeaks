using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public float foodValue = 10f; // Valeur nutritionnelle de cet item

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // V�rifie si le joueur collecte l'item
        {
            FoodBarController foodBar = FindObjectOfType<FoodBarController>();
            if (foodBar != null)
            {
                foodBar.AddFood(foodValue); // Ajoute la nourriture � la barre
            }
            Destroy(gameObject); // D�truit l'objet apr�s collecte
        }
    }
}
