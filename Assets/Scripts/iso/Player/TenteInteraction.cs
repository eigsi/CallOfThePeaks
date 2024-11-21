using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour le changement de scène

public class TenteInteraction : MonoBehaviour
{
    private bool isNearTent = false; 
    public string sceneToLoad;

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
        // Change la scène
        Debug.Log("Changement de scène vers : " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}
