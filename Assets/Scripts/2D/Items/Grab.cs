using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public LayerMask groundLayer; // Assigner le layer Ground ici
    public float grabDuration = 2f; // Durée maximale de l'accrochage en secondes
    public float verticalSpeed = 10f; // Vitesse de déplacement vertical
    public float cooldownTime = 2f; // Temps de délai entre deux utilisations

    private Rigidbody2D rb;
    private bool isGrabing = false;
    private float grabTimer = 0f;
    private float cooldownTimer = 0f; // Timer de délai entre deux utilisations

    private SpriteRenderer spriteToDisable;
    private PlayerController playerController;

    private bool isTouchingWall = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteToDisable = transform.Find("Crampon")?.GetComponent<SpriteRenderer>();

        playerController = GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogWarning("PlayerController n'a pas été trouvé sur ce GameObject.");
        }
    }

    void Update()
    {
        //cooldownTimer += Time.deltaTime;

        // Si les conditions pour grab sont remplies
        if (Input.GetButton("Fire3") && isTouchingWall && grabTimer < grabDuration /*&& cooldownTimer >= cooldownTime*/)
        {
            StartGrabing();
            grabTimer += Time.deltaTime;

            if (spriteToDisable != null)
            {
                spriteToDisable.enabled = false;
            }

            float verticalInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * verticalSpeed * 2);

            if (playerController != null)
            {
                playerController.timesJumped = 0;
            }
        }
        else
        {
            StopGrabing();

            if (!Input.GetButton("Fire3")) // Réinitialisation seulement si le bouton est relâché
            {
                grabTimer = 0f;
            }
        }
    }

    private void StartGrabing()
    {
        if (!isGrabing)
        {
            rb.gravityScale = 0; // Désactive la gravité pour permettre le mouvement vertical
            isGrabing = true;
            cooldownTimer = 0f;
        }
    }

    private void StopGrabing()
    {
        if (isGrabing)
        {
            rb.gravityScale = 1; // Réactive la gravité
            rb.velocity = new Vector2(rb.velocity.x, 0); // Arrête le mouvement vertical
            isGrabing = false;

            if (spriteToDisable != null)
            {
                spriteToDisable.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isTouchingWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isTouchingWall = false;
        }
    }
}
