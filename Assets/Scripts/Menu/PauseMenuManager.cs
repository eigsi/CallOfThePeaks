using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenu; // R�f�rence au panneau du menu de pause
    private bool isPaused = false; // Indique si le jeu est en pause

    void Update()
    {
        // V�rifier si le joueur appuie sur "Echap" pour ouvrir/fermer le menu de pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true); // Activer le menu de pause
        Time.timeScale = 0; // Mettre le jeu en pause
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // D�sactiver le menu de pause
        Time.timeScale = 1; // Reprendre le jeu
        isPaused = false;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1; // Remettre le temps � la normale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharger la sc�ne actuelle
    }

    public void QuitGame()
    {
        Time.timeScale = 1; // Remettre le temps � la normale
        SceneManager.LoadScene("MainMenu"); // Charger la sc�ne du menu principal
    }
}

