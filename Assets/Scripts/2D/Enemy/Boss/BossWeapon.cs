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

	[Header("Vomit Attack")]
    public GameObject JetDeGlace;
	public int vomitAttackDamage = 1;
   


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

	// void OnDrawGizmosSelected()
	// {
	// 	Vector3 pos = transform.position;
	// 	pos += transform.right * attackOffset.x;
	// 	pos += transform.up * attackOffset.y;

	// 	Gizmos.DrawWireSphere(pos, punchAttackDamage);
	// }
}
