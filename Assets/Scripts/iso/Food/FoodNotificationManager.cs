using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FoodNotificationManager : MonoBehaviour
{
    public TMP_Text notificationText; // Référence au texte de notification
    public float displayDuration = 2f; // Durée d'affichage de la notification

    private Coroutine notificationCoroutine;

    public void ShowNotification(float foodValue)
    {
        // Arrête toute notification précédente
        if (notificationCoroutine != null)
        {
            StopCoroutine(notificationCoroutine);
        }

        // Crée le texte de la notification avec le montant spécifique
        notificationText.text = $"+{foodValue} Food Collected!";

        // Démarre l'affichage de la notification
        notificationCoroutine = StartCoroutine(HideNotificationAfterDelay());
    }


    private IEnumerator HideNotificationAfterDelay()
    {
        // Affiche la notification pendant la durée spécifiée
        notificationText.gameObject.SetActive(true);

        yield return new WaitForSeconds(displayDuration);

        // Cache la notification après le délai
        notificationText.gameObject.SetActive(false);
    }
}

