using System.Collections;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public LayerMask groundLayer; // Assigner le layer Ground ici
    public float grabDuration = 2f; // Durée maximale de l'accrochage en secondes
    public float verticalSpeed = 5f; // Vitesse de déplacement vertical
    private Rigidbody2D rb;
    private bool isGrabing = false;
    private float grabTimer = 0f;

    [SerializeField] private PlayerController playerController; // Assigner via l'Inspecteur

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButton("Fire3") && playerController.grounded && grabTimer < grabDuration)
        {
            StartGrabing();
            grabTimer += Time.deltaTime;

            // Contrôle du mouvement vertical
            float verticalInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * verticalSpeed);
        }
        else
        {
            StopGrabing();
            grabTimer = 0f; // Réinitialise le compteur quand on relâche ou dépasse la durée
        }
    }

    private void StartGrabing()
    {
        if (!isGrabing)
        {
            rb.gravityScale = 0; // Désactive la gravité pour permettre le mouvement vertical
            isGrabing = true;
        }
    }

    private void StopGrabing()
    {
        if (isGrabing)
        {
            rb.gravityScale = 1; // Réactive la gravité
            rb.velocity = new Vector2(rb.velocity.x, 0); // Réinitialise la vitesse verticale
            isGrabing = false;
        }
    }
}
