using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grapple : MonoBehaviour
{
    public LayerMask grappinableLayers;
    public Transform pointDeLancement;
    public float distanceMax = 10f;
    public float vitesseDeTirage = 10f;
    public float delaiGrappin = 1f;
    public GameObject teteDuGrappinPrefab;
    public AudioClip grapplingSound;       // Son du grappin
    private AudioSource audioSource;       // Source audio pour jouer le son

    private GameObject teteDuGrappin;
    private Vector2 pointDAccroche;
    private bool estGrappe = false;
    private Rigidbody2D rb;
    private LineRenderer lineRenderer;

    private bool peutUtiliserGrappin = true;
    private SpriteRenderer spriteToDisable;

    public InputManager inputManager = null;

    public bool grappleInput
    {
        get
        {
            if (inputManager != null)
                return inputManager.grappleStarted;
            else
                return false;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteToDisable = transform.Find("Grappin").GetComponent<SpriteRenderer>();

        teteDuGrappin = Instantiate(teteDuGrappinPrefab);
        teteDuGrappin.SetActive(false);

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = new Color(0.36f, 0.25f, 0.2f);
        lineRenderer.enabled = false;

        // Ajouter le composant AudioSource si nécessaire
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;    // Ne pas jouer automatiquement
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && peutUtiliserGrappin)
        {
            LancerGrappin();
        }

        if (estGrappe)
        {
            TirerVersPoint();
            MettreAJourCorde();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            RelacherGrappin();
        }
    }

    void LancerGrappin()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - pointDeLancement.position;
        RaycastHit2D hit = Physics2D.Raycast(pointDeLancement.position, direction, distanceMax, grappinableLayers);

        if (hit.collider != null)
        {
            estGrappe = true;
            pointDAccroche = hit.point;

            teteDuGrappin.SetActive(true);
            teteDuGrappin.transform.position = pointDAccroche;

            if (spriteToDisable != null)
            {
                spriteToDisable.enabled = false;
            }

            Vector2 directionGrappin = pointDAccroche - (Vector2)pointDeLancement.position;
            float angle = Mathf.Atan2(directionGrappin.y, directionGrappin.x) * Mathf.Rad2Deg;
            teteDuGrappin.transform.rotation = Quaternion.Euler(0, 0, angle - 90f);

            lineRenderer.enabled = true;

            // Jouer le son du grappin
            if (audioSource != null && grapplingSound != null)
            {
                audioSource.PlayOneShot(grapplingSound);
            }

            StartCoroutine(DelaiUtilisationGrappin());
        }
    }

    void TirerVersPoint()
    {
        Vector2 position = Vector2.Lerp(transform.position, pointDAccroche, vitesseDeTirage * Time.deltaTime);
        rb.MovePosition(position);

        if (Vector2.Distance(transform.position, pointDAccroche) < 0.5f)
        {
            RelacherGrappin();
        }
    }

    void RelacherGrappin()
    {
        estGrappe = false;
        teteDuGrappin.SetActive(false);
        lineRenderer.enabled = false;

        if (spriteToDisable != null)
        {
            spriteToDisable.enabled = true;
        }
    }

    void MettreAJourCorde()
    {
        if (lineRenderer.enabled)
        {
            lineRenderer.SetPosition(0, pointDeLancement.position);
            lineRenderer.SetPosition(1, pointDAccroche);
        }
    }

    private IEnumerator DelaiUtilisationGrappin()
    {
        peutUtiliserGrappin = false;
        yield return new WaitForSeconds(delaiGrappin);
        peutUtiliserGrappin = true;
    }
}
