using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    public int damage = 1; // Dégâts infligés par une particule
    public Health playerHeath;

    void OnParticleCollision()
    {
        if (playerHeath != null)
        {
            playerHeath.TakeDamage(damage);
            Debug.Log($"Particule a infligé {damage} dégâts à {playerHeath.name}");
        }
    }
}

