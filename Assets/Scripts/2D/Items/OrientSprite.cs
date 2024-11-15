using UnityEngine;

public class OrientSprite : MonoBehaviour
{
    public Transform[] spritesToRotate; // Glissez ici les sprites que vous souhaitez orienter
    public bool flipOnXAxis = true; // Option pour inverser sur l'axe X si besoin

    private void Update()
    {
        // Obtient la direction de mouvement du personnage
        float direction = Input.GetAxis("Horizontal");

        if (direction != 0)
        {
            // Calcule le facteur de rotation (1 pour droite, -1 pour gauche)
            float orientationFactor = flipOnXAxis ? Mathf.Sign(direction) : 1;

            // Applique cette orientation uniquement aux sprites dans le tableau
            foreach (Transform sprite in spritesToRotate)
            {
                Vector3 newScale = sprite.localScale;
                newScale.x = orientationFactor * Mathf.Abs(newScale.x);
                sprite.localScale = newScale;
            }
        }
    }
}
