using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuManager : MonoBehaviour
{
    public void RestartPreviousLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Obtenir l'index de la sc�ne actuelle

        // V�rifier si un niveau pr�c�dent existe
        if (currentSceneIndex > 1) // Assurez-vous de ne pas revenir au menu principal (index 0)
        {
            SceneManager.LoadScene(currentSceneIndex - 1); // Charger la sc�ne pr�c�dente
        }
        else
        {
            Debug.LogWarning("Il n'y a pas de niveau pr�c�dent !");
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1; // Remettre le temps � la normale si n�cessaire
        SceneManager.LoadScene("MainMenu"); // Charger le menu principal
    }
}

