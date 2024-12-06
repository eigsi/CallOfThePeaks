using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public Vector3 attackOffset;
	public LayerMask attackMask;
	public Health playerHealth;

	[Header("Punch Attack")]
	public int punchAttackDamage = 1;
	public float punchAttackRange = 1f;

	[Header("Throw Attack")]
	public GameObject BouleDeNeige;
	public Transform launchPoint; // Point d'où le projectile est lancé
    public float launchSpeed = 10f; // Puissance de lancement
	public int throwAttackDamage = 1;

	[Header("Vomit Attack")]
    public GameObject JetDeGlace;
	public int vomitAttackDamage = 1;

    [Header("Player")]
	public Transform player;


    private float nextDamageTime = 0f;

	public void PunchAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, punchAttackRange, attackMask);
		if (colInfo != null)
		{
			playerHealth.TakeDamage(punchAttackDamage);
		}
	}

	public void StartVomitAttack()
	{
		JetDeGlace.SetActive(true);
	}

    public void StopVomitAttack()
    {
        JetDeGlace.SetActive(false);
    }

	public void StartThrowAttack()
	{
		if (player == null) return;

        // Instancier le projectile
        GameObject projectile = Instantiate(BouleDeNeige, launchPoint.position, Quaternion.identity);

        // Calculer la direction et la force nécessaires
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = CalculateLaunchVelocity(player.position, launchPoint.position, launchSpeed);
            rb.velocity = direction; // Appliquer la vitesse au Rigidbody
        }
	}

    Vector2 CalculateLaunchVelocity(Vector2 target, Vector2 origin, float speed)
    {
        // Différence de position
        Vector2 displacement = target - origin;

        // Calcul de la hauteur (choisir une hauteur arbitraire pour la cloche)
        float height = Mathf.Abs(displacement.y) + 2f;

        // Temps de vol (approximation pour parabole)
        float time = Mathf.Sqrt((2 * height) / Physics2D.gravity.magnitude) +
                     Mathf.Sqrt((2 * (displacement.y - height)) / Physics2D.gravity.magnitude);

        // Calculer la vitesse horizontale et verticale
        float vx = displacement.x / time;
        float vy = (height * 2f / time) - (Physics2D.gravity.magnitude * time / 2);

        return new Vector2(vx, vy); // Vitesse en x et y
    }
}
