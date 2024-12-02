using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuManager : MonoBehaviour
{
    public void RestartPreviousLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Obtenir l'index de la scène actuelle

        // Vérifier si un niveau précédent existe
        if (currentSceneIndex > 1) // Assurez-vous de ne pas revenir au menu principal (index 0)
        {
            SceneManager.LoadScene(currentSceneIndex - 1); // Charger la scène précédente
        }
        else
        {
            Debug.LogWarning("Il n'y a pas de niveau précédent !");
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1; // Remettre le temps à la normale si nécessaire
        SceneManager.LoadScene("MainMenu"); // Charger le menu principal
    }
}

