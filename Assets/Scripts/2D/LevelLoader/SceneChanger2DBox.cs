using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger2DBox : MonoBehaviour
{
    [Header("Settings")]
    public string nameOfSceneToLoad;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(nameOfSceneToLoad);
        }
    }
}
