using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger2D : MonoBehaviour
{
    public string sceneToLoad;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ChangeScene();
        }
    }
    


    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeScene()
    {
        LoadScene(sceneToLoad);
    }
}
