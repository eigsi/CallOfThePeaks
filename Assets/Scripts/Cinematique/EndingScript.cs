using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    public GameObject fleurDesactivee;
    public GameObject pas;
    public Animator animatorcam;

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
}
