using UnityEngine;

[ExecuteInEditMode]
public class SpriteSorter : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Décalage optionnel pour ajuster le sorting order
    public int sortingOrderOffset = 0;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        if (spriteRenderer != null)
        {
            // Calcul du sorting order basé sur la position Y
            spriteRenderer.sortingOrder = -(int)(transform.position.y * 100) + sortingOrderOffset;
        }
    }
}
