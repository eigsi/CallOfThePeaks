using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHearts = 3; // Nombre maximum de c�urs
    private int currentHearts;

    public Image[] heartImages; // Tableau d'images des c�urs
    public GameObject gameOverPanel; // R�f�rence au panneau Game Over

    void Start()
    {
        currentHearts = maxHearts;
        UpdateHeartsUI();
        gameOverPanel.SetActive(false); // Masquer l'�cran Game Over au d�but
    }

    public void TakeDamage()
    {
        if (currentHearts > 0)
        {
            currentHearts--; // R�duire le nombre de c�urs
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
                heartImages[i].enabled = true; // Affiche le c�ur
            else
                heartImages[i].enabled = false; // Masque le c�ur
        }
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true); // Afficher l'�cran Game Over
        Time.timeScale = 0; // Mettre le jeu en pause
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Relancer le temps
        // Ajoutez ici votre logique pour red�marrer le jeu ou recharger la sc�ne
    }
}

