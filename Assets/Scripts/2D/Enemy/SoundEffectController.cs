using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundEffectController : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Exemple : Ajuster le volume en fonction de la distance avec le joueur
        GameObject player = GameObject.FindWithTag("Player");
        float distance = Vector2.Distance(player.transform.position, transform.position);

        // Modifier la spatialisation manuellement
        audioSource.volume = Mathf.Clamp01(1 - (distance / audioSource.maxDistance));
    }
}
