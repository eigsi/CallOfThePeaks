using UnityEngine;
using UnityEngine.UI;

public class FoodBarController : MonoBehaviour
{
    public Image foodFill; // L'image représentant la barre de nourriture
    public float maxFood = 100f; // Quantité maximale de nourriture
    private float currentFood; // Quantité actuelle de nourriture
    public AudioClip foodSound;
    private AudioSource audioSource;

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
}
