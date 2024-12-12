using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	[Header("Settings")]
    public string nameOfSceneToLoad;

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

        // Instanciation du projectile
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Le prefab du projectile doit contenir un Rigidbody2D.");
            Destroy(projectile);
            return;
        }

        // Calcul de la vélocité
        Vector2 velocity = CalculateLaunchVelocity(player.position, launchPoint.position, launchSpeed, arcHeight);

        if (velocity == Vector2.zero)
        {
            Debug.LogError("La vitesse calculée est invalide, le projectile ne sera pas lancé.");
            Destroy(projectile);
            return;
        }

        // Appliquer la vélocité
        rb.velocity = velocity;

        // Ajouter le script Snowball pour gérer la destruction
        Snowball snowball = projectile.AddComponent<Snowball>();
        snowball.groundMask = groundMask;
    }

    private Vector2 CalculateLaunchVelocity(Vector2 target, Vector2 origin, float speed, float height)
    {
        Vector2 displacement = target - origin;

        // Ajustement des paramètres si nécessaire
        if (Mathf.Abs(displacement.x) < 0.01f) displacement.x = 0.01f; // Prévenir divisions par zéro

        // Calcul du temps de vol basé sur l'équation du mouvement
        float timeToApex = Mathf.Sqrt(2 * height / Physics2D.gravity.magnitude);
        if (timeToApex <= 0) return Vector2.zero;

        float totalTime = timeToApex + Mathf.Sqrt(2 * Mathf.Abs(displacement.y - height) / Physics2D.gravity.magnitude);
        if (totalTime <= 0) return Vector2.zero;

        // Composantes de la vélocité
        float vx = displacement.x / totalTime;
        float vy = (2 * height / timeToApex) - (Physics2D.gravity.magnitude * timeToApex);

        // Validation des valeurs calculées
        if (float.IsNaN(vx) || float.IsNaN(vy))
        {
            Debug.LogError($"Vitesse invalide calculée : vx = {vx}, vy = {vy}");
            return Vector2.zero;
        }

        return new Vector2(vx, vy);
    }

	private void SceneChanger()
    {
        SceneManager.LoadScene(nameOfSceneToLoad);
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
