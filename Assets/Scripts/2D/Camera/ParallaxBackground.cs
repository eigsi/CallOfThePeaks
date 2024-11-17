using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public PlayerController player; // Référence au PlayerController
    public float parallaxSpeed = 0.5f; // Vitesse de défilement relative

    private Material material; // Matériau du fond
    private Vector2 offset; // Décalage du matériau

    void Start()
    {
        // Récupérer le matériau attaché au Renderer
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (player != null)
        {
            // Utiliser la vitesse du joueur pour calculer le déplacement
            float movement = player.PlayerRigidbody.velocity.x * parallaxSpeed;
            offset += new Vector2(movement * Time.deltaTime, 0);

            // Appliquer l'offset au matériau
            material.mainTextureOffset = offset;
        }
    }
}
