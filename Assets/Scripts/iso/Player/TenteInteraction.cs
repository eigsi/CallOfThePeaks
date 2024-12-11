using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Pour utiliser TMP_Text

public class TenteInteraction : MonoBehaviour
{
    private bool isNearTent = false;
    public string sceneToLoad;

    // Référence à la barre d'alimentation
    public FoodBarController foodBarController;

    // Référence vers le texte TMP
    public TMP_Text notificationText;

    void Update()
    {
        if (isNearTent && Input.GetKeyDown(KeyCode.E))
        {
            ChangeScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tente"))
        {
            isNearTent = true;
            Debug.Log("Vous êtes à côté de la tente. Appuyez sur 'E' pour entrer.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tente"))
        {
            isNearTent = false;
            Debug.Log("Vous vous êtes éloigné de la tente.");
        }
    }

    private void ChangeScene()
    {
        // Vérifie si la barre d'alimentation est à 100 ou plus
        if (foodBarController != null && foodBarController.IsFoodBarFull())
        {
            Debug.Log("Changement de scène vers : " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.Log("La barre d'alimentation n'est pas encore pleine (100 ou plus).");

            // Affichage du message avec TMP_Text en bas de l'écran
            if (notificationText != null)
            {
                notificationText.text = "Your food bar is not full !";
                notificationText.gameObject.SetActive(true);
                // Masquer après quelques secondes
                StartCoroutine(HideNotificationAfterDelay(3f));
            }
        }
    }

    private IEnumerator HideNotificationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (notificationText != null)
        {
            notificationText.gameObject.SetActive(false);
        }
    }
}
