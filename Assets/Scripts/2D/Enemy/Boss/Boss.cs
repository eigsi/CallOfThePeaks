using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

	public Transform player;

	public bool isFlipped = false;
	private Rigidbody2D bossRigidbody = null;


	[Header("Boss")]
	[Tooltip("Boss jump force.")]
	public float jumpPower = 1.0f;

	[Header("References")]
    [Tooltip("The layers which are considered \"Ground\".")]
    public LayerMask groundLayers = new LayerMask();
	[Tooltip("The ground check component used to test whether this enemy has hit a wall to the right.")]
    public Collider2D wallTestFront;


	private void Start()
	{
		bossRigidbody = GetComponent<Rigidbody2D>();
		if (bossRigidbody == null)
		{
			Debug.LogError("Rigidbody2D n'est pas attaché à " + gameObject.name);
		}
	}
	
	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}
	public void Update()
	{
		TestWall(wallTestFront);
	}

	protected virtual void TestWall(Collider2D wallTestFront)
    {
        if (IsInLayerMask(wallTestFront.gameObject, groundLayers))
        {
            bossRigidbody.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        }
    }

	private bool IsInLayerMask(GameObject obj, LayerMask layerMask)
    {
        return (layerMask.value & (1 << obj.layer)) != 0;
    }

}
