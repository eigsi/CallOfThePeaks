using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenu; // Référence au panneau du menu de pause
    public GameObject canvas1;   // Référence au premier Canvas à désactiver
    public GameObject canvas2;   // Référence au second Canvas à désactiver
    private bool isPaused = false; // Indique si le jeu est en pause

    void Start()
    {
        // Désactiver le menu de pause au démarrage du jeu
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        // Vérifier si le joueur appuie sur "Echap" pour ouvrir/fermer le menu de pause
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
        canvas1.SetActive(false); // Désactiver le premier Canvas
        canvas2.SetActive(false); // Désactiver le second Canvas
        Time.timeScale = 0; // Mettre le jeu en pause
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // Désactiver le menu de pause
        canvas1.SetActive(true); // Réactiver le premier Canvas 
        Time.timeScale = 1; // Reprendre le jeu
        isPaused = false;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1; // Remettre le temps à la normale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharger la scène actuelle
    }

    public void QuitGame()
    {
        Time.timeScale = 1; // Remettre le temps à la normale
        SceneManager.LoadScene("MainMenu"); // Charger la scène du menu principal
    }
}
