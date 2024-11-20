using UnityEngine;

public class QuitGameButton : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quitter le jeu !");

        // Ferme le jeu si vous êtes en build
        Application.Quit();

        // Affiche un message dans l'éditeur Unity (ne fonctionne pas dans une build)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
