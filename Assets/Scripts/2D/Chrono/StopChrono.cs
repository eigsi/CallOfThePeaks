using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopChrono : MonoBehaviour
{
    // Update is called once per frame
    void Stop()
    {
         // Vérifie si l'instance de ChronoManager existe
        if (Chrono.instance != null)
        {
            // Appelle la méthode StopChrono pour arrêter le chronomètre
            Chrono.instance.StopChrono();
        }
        else
        {
            Debug.LogWarning("ChronoManager n'est pas disponible.");
        }
    }
}
