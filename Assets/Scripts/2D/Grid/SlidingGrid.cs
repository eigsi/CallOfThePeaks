using UnityEngine;

public class SlidingGrid : MonoBehaviour
{
    public float slidingForce = 5f; // Force de glissement à appliquer

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Vérifie si l'objet en contact est le joueur (par exemple, tag "Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Applique une force dans la direction du mouvement actuel du joueur
                Vector2 slidingDirection = rb.velocity.normalized;
                rb.AddForce(slidingDirection * slidingForce, ForceMode2D.Force);
            }
        }
    }
}
