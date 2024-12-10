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
	public GameObject projectilePrefab; // Prefab de la boule de neige
    public Transform launchPoint;       // Point de lancement
    public float launchSpeed = 10f;     // Vitesse initiale
    public float arcHeight = 2f;        // Hauteur de l'arc
    public LayerMask groundMask;        // Couches considérées comme "sol"

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
        if (player == null)
        {
            Debug.LogError("Impossible de lancer l'attaque : le joueur est introuvable.");
            return;
        }

        // Instancier la boule de neige
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);

        // Appliquer la trajectoire
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 velocity = CalculateLaunchVelocity(player.position, launchPoint.position, launchSpeed, arcHeight);

            if (velocity == Vector2.zero)
            {
                Debug.LogError("La vitesse calculée est invalide.");
                Destroy(projectile);
                return;
            }

            rb.velocity = velocity;

            // Détruire la boule de neige après impact
            Snowball snowball = projectile.AddComponent<Snowball>();
            snowball.groundMask = groundMask;
        }
        else
        {
            Debug.LogError("Le projectile instancié n'a pas de Rigidbody2D.");
        }
    }

    private Vector2 CalculateLaunchVelocity(Vector2 target, Vector2 origin, float speed, float height)
	{
		// Calculer le déplacement
		Vector2 displacement = target - origin;

		// Prévenir les divisions par zéro pour x
		if (Mathf.Abs(displacement.x) < 0.01f)
		{
			Debug.LogWarning("Distance horizontale trop faible, ajustement automatique.");
			displacement.x = 0.01f; // Ajouter une petite valeur
		}

		// Vérifier la hauteur et la vitesse d'entrée
		if (height <= 0 || speed <= 0)
		{
			Debug.LogError("Hauteur ou vitesse invalide.");
			return Vector2.zero;
		}

		// Calcul du temps pour atteindre le sommet
		float timeToApex = Mathf.Sqrt(2 * height / Physics2D.gravity.magnitude);
		if (timeToApex <= 0)
		{
			Debug.LogError("Temps pour atteindre le sommet invalide.");
			return Vector2.zero;
		}

		// Temps total de vol
		float totalTime = timeToApex + Mathf.Sqrt(2 * (displacement.y - height) / Physics2D.gravity.magnitude);
		if (totalTime <= 0)
		{
			Debug.LogError("Temps total de vol invalide.");
			return Vector2.zero;
		}

		// Calcul des composantes de la vitesse
		float vx = displacement.x / totalTime; // Vitesse horizontale
		float vy = (2 * height / timeToApex) - (Physics2D.gravity.magnitude * timeToApex); // Vitesse verticale

		// Vérification finale
		if (float.IsNaN(vx) || float.IsNaN(vy))
		{
			Debug.LogError($"Vitesse invalide calculée : vx = {vx}, vy = {vy}");
			return Vector2.zero;
		}

		return new Vector2(vx, vy);
	}
}

public class Snowball : MonoBehaviour
{
    public LayerMask groundMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Détruire la boule de neige si elle touche le sol
        if (groundMask == (groundMask | (1 << collision.gameObject.layer)))
        {
            Destroy(gameObject);
        }
    }
}
