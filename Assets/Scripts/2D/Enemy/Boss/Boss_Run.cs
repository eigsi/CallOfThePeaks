using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{

	public float speed = 2.5f;
	public float punchAttackRange = 1.5f;
	public float attackCooldownPunch = 4f; // Temps de récupération entre les attaques punch

	public float throwAttackRange1 = 1.5f;
	public float throwAttackRange2 = 5f;
	public float attackCooldownThrow = 8f; // Temps de récupération entre les attaques vomit

	public float vomitAttackRange1 = 5f;
	public float vomitAttackRange2 = 10f;
	public float attackCooldownVomit = 10f; // Temps de récupération entre les attaques vomit

	private float cooldownTimer; // Chronomètre pour le cooldown des attaques

	Transform player;
	Rigidbody2D rb;
	Boss boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = animator.GetComponent<Rigidbody2D>();
		boss = animator.GetComponent<Boss>();

		cooldownTimer = 0f; // Réinitialise le cooldown au début de l'état

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		boss.LookAtPlayer();

		Vector2 target = new Vector2(player.position.x, rb.position.y);
		Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
		rb.MovePosition(newPos);

		//Attack Punch
		if ( Vector2.Distance(player.position, rb.position) <= punchAttackRange && cooldownTimer >= attackCooldownPunch )
		{
			animator.SetTrigger("Punch");
			cooldownTimer = 0f; // Réinitialise le cooldown au début de l'état
		}
		//Attack Throw
		if ( throwAttackRange1 <= Vector2.Distance(player.position, rb.position) && Vector2.Distance(player.position, rb.position) <= throwAttackRange2 && cooldownTimer >= attackCooldownThrow )
		{
			animator.SetTrigger("Punch");
			cooldownTimer = 0f; // Réinitialise le cooldown au début de l'état
		}
		//Attack Vomit
		if ( vomitAttackRange1 <= Vector2.Distance(player.position, rb.position) && Vector2.Distance(player.position, rb.position) <= vomitAttackRange2 && cooldownTimer >= attackCooldownVomit )
		{
			animator.SetTrigger("Vomit");
			cooldownTimer = 0f; // Réinitialise le cooldown au début de l'état
		}else{
			cooldownTimer += Time.deltaTime;
			return; // Arrête l'évaluation des attaques tant que le cooldown n'est pas fini
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.ResetTrigger("Punch");
		animator.ResetTrigger("Vomit");
	}
}
