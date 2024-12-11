using UnityEngine;
using UnityEngine.UI;

public class FoodBarController : MonoBehaviour
{
    public Image foodFill; // L'image représentant la barre de nourriture
    public float maxFood = 100f; // Quantité maximale de nourriture
    private float currentFood; // Quantité actuelle de nourriture
    public AudioClip foodSound;
    private AudioSource audioSource;
    private FoodItem currentFoodItem; // Référence au FoodItem à proximité

    void Start()
    {
        currentFood = 0.01f; // Initialise la barre à zéro
        UpdateFoodBar();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Vérifie si l'utilisateur appuie sur "E" et qu'un item est à proximité
        if (Input.GetKeyDown(KeyCode.E) && currentFoodItem != null)
        {
            CollectFood(); // Ramasse la nourriture si un item est à proximité
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        FoodItem foodItem = other.GetComponent<FoodItem>();
        if (foodItem != null && !foodItem.isCollected) // Vérifie que l'item n'est pas déjà collecté
        {
            currentFoodItem = foodItem; // Enregistre l'item à proximité
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        FoodItem foodItem = other.GetComponent<FoodItem>();
        if (foodItem != null && foodItem == currentFoodItem)
        {
            currentFoodItem = null; // Efface la référence si l'item n'est plus à proximité
        }
    }

    private void CollectFood()
    {
        if (currentFoodItem != null && !currentFoodItem.isCollected)
        {
            AddFood(currentFoodItem.foodValue); // Ajoute la nourriture
            currentFoodItem.ReplaceItem(); // Remplace l'item (ou change son sprite)
        }
    }

    public void AddFood(float amount)
    {
        Debug.Log($"Before adding food: {currentFood}");

        currentFood += amount; // Ajoute la nourriture
        currentFood = Mathf.Clamp(currentFood, 0, maxFood); // Empêche de dépasser max

        Debug.Log($"After adding food: {currentFood}");

        UpdateFoodBar(); // Mets à jour l'affichage
        PlaySoundEffect();
    }

    private void UpdateFoodBar()
    {
        foodFill.fillAmount = currentFood / maxFood; // Met à jour la barre
    }

    private void PlaySoundEffect()
    {
        if (foodSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(foodSound); // Joue le son une fois
        }
    }

    public bool IsFoodBarFull()
    {
        return currentFood >= maxFood;
    }


}
