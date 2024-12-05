using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks; // Nécessaire pour Task.Delay
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health = 9;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{

		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 6)
		{
			GetComponent<Animator>().SetBool("isPhase2", true);
			GetComponent<Animator>().SetBool("isPhase1", false);
		}
		if (health <= 3)
		{
			GetComponent<Animator>().SetBool("isPhase3", true);
			GetComponent<Animator>().SetBool("isPhase2", false);
		}

		if (health <= 0)
		{
			GetComponent<Animator>().SetBool("isDead", true);
			GetComponent<Animator>().SetBool("isPhase3", false);
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		GetComponent<Animator>().SetBool("isDead", false);
	}

}
