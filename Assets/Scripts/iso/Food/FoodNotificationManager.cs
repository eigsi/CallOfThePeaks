using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FoodNotificationManager : MonoBehaviour
{
    public TMP_Text notificationText; // R�f�rence au texte de notification
    public float displayDuration = 2f; // Dur�e d'affichage de la notification

    private Coroutine notificationCoroutine;

    public void ShowNotification(float foodValue)
    {
        // Arr�te toute notification pr�c�dente
        if (notificationCoroutine != null)
        {
            StopCoroutine(notificationCoroutine);
        }

        // Cr�e le texte de la notification avec le montant sp�cifique
        notificationText.text = $"+{foodValue} Food Collected!";

        // D�marre l'affichage de la notification
        notificationCoroutine = StartCoroutine(HideNotificationAfterDelay());
    }


    private IEnumerator HideNotificationAfterDelay()
    {
        // Affiche la notification pendant la dur�e sp�cifi�e
        notificationText.gameObject.SetActive(true);

        yield return new WaitForSeconds(displayDuration);

        // Cache la notification apr�s le d�lai
        notificationText.gameObject.SetActive(false);
    }
}

