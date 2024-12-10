using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePositionLoader : MonoBehaviour
{
    [Header("Settings")]
    public string nameOfSceneToLoad;
    public Vector3 targetPosition; // Position cible pour le joueur dans la nouvelle scène

    private bool isTransitioning = false; // Empêche de déclencher plusieurs fois

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTransitioning)
        {
            isTransitioning = true;

            // Enregistrer la position cible dans le gestionnaire
            SceneTransitionManager.Instance.SetTargetPosition(targetPosition);

            // Charger la nouvelle scène
            SceneManager.LoadScene(nameOfSceneToLoad);
        }
    }
}
