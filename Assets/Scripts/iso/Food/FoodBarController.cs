using UnityEngine;
using UnityEngine.UI;

public class FoodBarController : MonoBehaviour
{
    public Image foodFill; // L'image représentant la barre de nourriture
    public float maxFood = 100f; // Quantité maximale de nourriture
    private float currentFood; // Quantité actuelle de nourriture

    void Start()
    {
        currentFood = 0.01f; // Initialise la barre à zéro
        UpdateFoodBar();
    }

    public void AddFood(float amount)
    {
        currentFood += amount; // Ajoute de la nourriture
        currentFood = Mathf.Clamp(currentFood, 0, maxFood); // Empêche de dépasser max
        UpdateFoodBar();
        Debug.Log($"Food added! Current food: {currentFood}"); // Vérifie l'ajout de nourriture
    }

    private void UpdateFoodBar()
    {
        foodFill.fillAmount = currentFood / maxFood; // Met à jour la barre
    }
}
