using UnityEngine;

public class PlayerPositionSetter : MonoBehaviour
{
    private void Start()
    {
        // Vérifiez si une position cible a été définie
        if (SceneTransitionManager.Instance != null && SceneTransitionManager.Instance.hasTargetPosition)
        {
            transform.position = SceneTransitionManager.Instance.targetPosition;

            // Réinitialisez la position cible après l'application
            SceneTransitionManager.Instance.ClearTargetPosition();
        }
    }
}
