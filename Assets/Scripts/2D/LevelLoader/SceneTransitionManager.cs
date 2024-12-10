using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    public Vector3 targetPosition; // Position cible pour le joueur dans la nouvelle scène
    public bool hasTargetPosition = false; // Indicateur pour savoir si une position a été définie

    private void Awake()
    {
        // Assure qu'une seule instance existe
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
        hasTargetPosition = true;
    }

    public void ClearTargetPosition()
    {
        hasTargetPosition = false;
    }
}
