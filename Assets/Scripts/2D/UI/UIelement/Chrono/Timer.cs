using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 180; // Time in seconds.
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public PlayerController playerController;

    void Start()
    {
        timerIsRunning = true;

        if (playerController == null)
        {
            Debug.LogError("PlayerController non assigné dans le script Timer !");
        }
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);

                if (timeRemaining <= 59)
                {
                    timeText.color = Color.red;
                }
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;

                if (playerController != null && playerController.playerHealth != null)
                {
                    HandlePlayerDeath();
                }
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // For the timer to start at 3:00 instead of 2:59.
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void HandlePlayerDeath()
    {
        playerController.playerHealth.TakeDamage(10); // Apply damage to kill the player

        playerController.playerHealth.currentLives -= 10; // - 10 lives so the player can't respawn

        if (playerController.playerHealth.currentLives < 0)
        {
            playerController.playerHealth.currentLives = 0;
        }

        Debug.Log($"Player took 10 damage and lost 10 lives. Lives remaining: {playerController.playerHealth.currentLives}");
    }
}
