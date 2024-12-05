using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public float foodValue = 10f; // Valeur nutritionnelle de cet item

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si le joueur collecte l'item
        {
            FoodBarController foodBar = FindObjectOfType<FoodBarController>();
            if (foodBar != null)
            {
                foodBar.AddFood(foodValue); // Ajoute la nourriture à la barre
            }
            Destroy(gameObject); // Détruit l'objet après collecte
        }
    }
}
