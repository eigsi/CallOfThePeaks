using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Référence au Transform du personnage à suivre
    public Transform target;

    // Décalage en Z (généralement négatif pour les jeux 2D)
    public float offsetZ = -10f;

    // Décalage optionnel sur les axes X et Y
    public Vector2 offset = Vector2.zero;

    // Vitesse de lissage de la caméra
    public float smoothSpeed = 0.1f;

    void LateUpdate()
    {
        if (target != null)
        {
            // Position désirée de la caméra
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, offsetZ);

            // Position lissée entre la position actuelle et la position désirée
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Appliquer la position lissée
            transform.position = smoothedPosition;
        }
    }
}
