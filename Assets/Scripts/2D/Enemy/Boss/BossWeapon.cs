using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public int punchAttackDamage = 1;
	public int vomitAttackDamage = 1;

	public Vector3 attackOffset;
	public float punchAttackRange = 1f;
	public float vomitAttackRange = 1f;
	public LayerMask attackMask;

	public Health playerHealth;

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

	public void VomitAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, vomitAttackRange, attackMask);
		if (colInfo != null)
		{
			playerHealth.TakeDamage(vomitAttackDamage);
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, punchAttackDamage);
	}
}
