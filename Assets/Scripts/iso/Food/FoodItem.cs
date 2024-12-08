using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public float foodValue = 10f; // Valeur nutritionnelle
    public Sprite replacementSprite;
    public bool isCollected { get; private set; } = false; // Indique si l'item a été collecté

    public void ReplaceItem()
    {
        if (!isCollected && replacementSprite != null)
        {
            isCollected = true; // Marque l'item comme collecté

            // Récupère le SpriteRenderer attaché à cet objet
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                // Change le sprite du SpriteRenderer
                spriteRenderer.sprite = replacementSprite;
            }

            // Désactive le collider pour empêcher toute interaction supplémentaire
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = false;
            }
        }
    }
}
