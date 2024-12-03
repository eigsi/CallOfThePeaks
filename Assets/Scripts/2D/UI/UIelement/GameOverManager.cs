using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [Tooltip("The canvas for the main game.")]
    public Canvas mainCanvas;
    [Tooltip("The canvas for the Game Over screen.")]
    public Canvas gameOverCanvas;
    [Tooltip("The player's health component.")]
    public Health playerHealth;

    void Start()
    {
        if (mainCanvas == null || gameOverCanvas == null || playerHealth == null)
        {
            Debug.LogError("References are missing in GameOverManager!");
            return;
        }

        // S'assurer que le canvas Game Over est désactivé au départ
        gameOverCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
    }

    void Update()
    {
        // Vérifier si le joueur n'a plus de vies
        if (playerHealth.currentLives <= 0)
        {
            ActivateGameOverCanvas();
        }
    }

    /// <summary>
    /// Activates the Game Over canvas and deactivates the main game canvas.
    /// </summary>
    private void ActivateGameOverCanvas()
    {
        mainCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);
    }
}
