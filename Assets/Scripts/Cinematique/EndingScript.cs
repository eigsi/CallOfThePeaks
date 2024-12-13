using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    public GameObject fleurDesactivee;
    public GameObject pas;
    public Animator animatorcam;

    [Header("Settings")]
    public string nameOfSceneToLoad;

    public void AttrapeFleur()
    {
        animatorcam.SetTrigger("Attrape");
    }

    public void StepsSFX ()
    {
        if (pas != null)
        {
            Instantiate(pas, transform.position, transform.rotation, null);
        }
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene(nameOfSceneToLoad);
    }
}
