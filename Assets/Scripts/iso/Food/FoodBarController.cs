using UnityEngine;
using UnityEngine.UI;

public class FoodBarController : MonoBehaviour
{
    public Image foodFill; // L'image repr�sentant la barre de nourriture
    public float maxFood = 100f; // Quantit� maximale de nourriture
    private float currentFood; // Quantit� actuelle de nourriture

    void Start()
    {
        currentFood = 0f; // Initialise la barre � z�ro
        UpdateFoodBar();
    }

    public void AddFood(float amount)
    {
        currentFood += amount; // Ajoute de la nourriture
        currentFood = Mathf.Clamp(currentFood, 0, maxFood); // Emp�che de d�passer max
        UpdateFoodBar();
        Debug.Log($"Food added! Current food: {currentFood}"); // V�rifie l'ajout de nourriture
    }

    private void UpdateFoodBar()
    {
        foodFill.fillAmount = currentFood / maxFood; // Met � jour la barre
    }
}
