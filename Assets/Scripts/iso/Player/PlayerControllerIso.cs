using UnityEngine;

public class PlayerControllerIso : MonoBehaviour
{
    // Vitesse de déplacement du personnage
    public float speed = 5f;

    // Référence à l'Animator
    private Animator animator;

    // Variable pour stocker la dernière direction
    private string lastDirection = "DownRight";

    void Start()
    {
        // Récupère l'Animator attaché au GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Création du vecteur de déplacement isométrique
        Vector3 movement = Vector3.zero;

        // Détection des touches pour les directions isométriques
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Z))
        {
            // Flèche Haut -> moveUpLeft
            movement += new Vector3(-1f, 1f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // Flèche Droite -> moveUpRight
            movement += new Vector3(1f, 1f, 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            // Flèche Bas -> moveDownRight
            movement += new Vector3(1f, -1f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q))
        {
            // Flèche Gauche -> moveDownLeft
            movement += new Vector3(-1f, -1f, 0f);
        }

        // Si le mouvement n'est pas nul, normalisez-le et déplacez le personnage
        if (movement != Vector3.zero)
        {
            movement.Normalize();
            // Déplacer le personnage
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }

        // Mettre à jour les animations
        UpdateAnimation(movement);
    }

    // Méthode pour mettre à jour l'animation en fonction du vecteur de mouvement
    void UpdateAnimation(Vector3 movement)
    {
        if (movement == Vector3.zero)
        {
            // État fixe, joue l'animation de repos dans la dernière direction
            animator.Play("stay" + lastDirection);
        }
        else
        {
            string direction = "";

            float x = movement.x;
            float y = movement.y;

            if (x > 0 && y > 0)
            {
                direction = "UpRight";
            }
            else if (x < 0 && y > 0)
            {
                direction = "UpLeft";
            }
            else if (x > 0 && y < 0)
            {
                direction = "DownRight";
            }
            else if (x < 0 && y < 0)
            {
                direction = "DownLeft";
            }

            // Stocke la dernière direction pour l'état immobile
            if (!string.IsNullOrEmpty(direction))
            {
                lastDirection = direction;
                // Joue l'animation de mouvement dans la direction appropriée
                animator.Play("move" + direction);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food")) // Vérifie si l'objet est un item de nourriture
        {
            Debug.Log($"Food item detected: {other.name}");

            FoodItem foodItem = other.GetComponent<FoodItem>();
            if (foodItem != null)
            {
                FoodBarController foodBar = FindObjectOfType<FoodBarController>();
                if (foodBar != null)
                {
                    foodBar.AddFood(foodItem.foodValue); // Ajoute la valeur nutritionnelle
                    Debug.Log($"Added {foodItem.foodValue} food to the bar.");
                }

                Destroy(other.gameObject); // Détruit l'item après collecte
            }
        }
    }
}
