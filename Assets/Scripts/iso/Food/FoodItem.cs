using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public float foodValue = 10f; // Valeur nutritionnelle
   public Sprite replacementSprite;

    public void ReplaceItem()
    {
        if (replacementSprite != null)
        {
            // Récupère le SpriteRenderer attaché à cet objet
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                // Change le sprite du SpriteRenderer
                spriteRenderer.sprite = replacementSprite;
            }
        }
    }
}
