using UnityEngine;

public class OrientSprite : MonoBehaviour
{
    public Transform spriteToRotate; // Assignez ici le sprite que vous souhaitez orienter
    public bool flipOnXAxis = true; // Option pour inverser sur l'axe X si besoin

    private void Update()
    {
        // Obtient la direction du personnage (positive si vers la droite, négative si vers la gauche)
        float direction = Input.GetAxis("Horizontal");

        if (direction != 0)
        {
            Vector3 newScale = spriteToRotate.localScale;
            newScale.x = flipOnXAxis ? Mathf.Sign(direction) * Mathf.Abs(newScale.x) : newScale.x;
            spriteToRotate.localScale = newScale;
        }
    }
}

