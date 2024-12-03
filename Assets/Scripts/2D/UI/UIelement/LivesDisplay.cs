using UnityEngine;
using TMPro;
using System.Collections;

public class LivesDisplay : MonoBehaviour
{
    [Tooltip("The Health component to track lives from.")]
    public Health playerHealth;
    [Tooltip("The TextMeshProUGUI component to display the lives.")]
    public TextMeshProUGUI livesText;

    private Vector3 originalPosition;
    private bool isShaking = false;

    void Start()
    {
        if (playerHealth == null)
        {
            Debug.LogError("Health component not assigned to LivesDisplay!");
        }

        if (livesText == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned to LivesDisplay!");
        }

        originalPosition = livesText.rectTransform.localPosition;

        // Update the lives display when the game starts
        UpdateLivesDisplay();
    }

    void Update()
    {
        // Update the lives display every frame
        UpdateLivesDisplay();
    }

    /// <summary>
    /// Updates the lives display text based on the player's current lives.
    /// </summary>
    private void UpdateLivesDisplay()
    {
        if (playerHealth != null && livesText != null)
        {
            livesText.text = "x" + playerHealth.currentLives;

            if (playerHealth.currentLives == 1)
            {
                livesText.color = Color.red;
                if (!isShaking)
                {
                    StartCoroutine(ShakeText());
                }
            }
            else
            {
                livesText.color = Color.white; 
                if (isShaking)
                {
                    StopAllCoroutines();
                    isShaking = false;
                    livesText.rectTransform.localPosition = originalPosition;
                }
            }
        }
    }
    private IEnumerator ShakeText()
    {
        isShaking = true;

        while (true)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-2f, 2f), // horizontal movement
                Random.Range(-2f, 2f), // vertical movement
                0);

            livesText.rectTransform.localPosition = originalPosition + randomOffset;

            yield return new WaitForSeconds(0.05f);
        }
    }
}
