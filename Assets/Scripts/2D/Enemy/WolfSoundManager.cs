using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSoundManager : MonoBehaviour
{
    public GameObject bark;
    public GameObject howl;
    public GameObject growl;
    public GameObject whines;


    public void Bark()
    {
        if (bark != null)
        {
            Instantiate(bark, transform.position, transform.rotation, null);
        }
    }

    public void Howl()
    {
        if (howl != null)
        {
            Instantiate(howl, transform.position, transform.rotation, null);
        }
    }

    public void Growl()
    {
        if (growl != null)
        {
            Instantiate(growl, transform.position, transform.rotation, null);
        }
    }

    public void Whines()
    {
        if (whines != null)
        {
            Instantiate(whines, transform.position, transform.rotation, null);
        }
    }
    
}
