using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player; // Référence au joueur
    public float chaseDistance = 5f; // Distance à partir de laquelle l'ennemi commence à poursuivre
    public float moveSpeed = 2f; // Vitesse de l'ennemi

    private bool isChasing = false;

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Le joueur n'est pas attribué !");
            return;
        }

        // Calculer la distance entre l'ennemi et le joueur
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Activer ou désactiver la poursuite en fonction de la distance
        if (distanceToPlayer <= chaseDistance)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        // Si l'ennemi poursuit le joueur
        if (isChasing)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
        }
    }
}

