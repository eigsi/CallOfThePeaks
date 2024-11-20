using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{
    [Tooltip("Nom de la sc�ne � charger")]
    public string sceneToLoad;

    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            Debug.Log($"Chargement de la sc�ne : {sceneToLoad}");
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Aucune sc�ne sp�cifi�e pour ce bouton !");
        }
    }
}
