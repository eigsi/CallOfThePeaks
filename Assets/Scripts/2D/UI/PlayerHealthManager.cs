using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHearts = 3; // Nombre maximum de cœurs
    private int currentHearts;

    public Image[] heartImages; // Tableau d'images des cœurs
    public GameObject gameOverPanel; // Référence au panneau Game Over

    void Start()
    {
        currentHearts = maxHearts;
        UpdateHeartsUI();
        gameOverPanel.SetActive(false); // Masquer l'écran Game Over au début
    }

    public void TakeDamage()
    {
        if (currentHearts > 0)
        {
            currentHearts--; // Réduire le nombre de cœurs
            UpdateHeartsUI();
        }

        if (currentHearts <= 0)
        {
            GameOver();
        }
    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHearts)
                heartImages[i].enabled = true; // Affiche le cœur
            else
                heartImages[i].enabled = false; // Masque le cœur
        }
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true); // Afficher l'écran Game Over
        Time.timeScale = 0; // Mettre le jeu en pause
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Relancer le temps
        // Ajoutez ici votre logique pour redémarrer le jeu ou recharger la scène
    }
}

