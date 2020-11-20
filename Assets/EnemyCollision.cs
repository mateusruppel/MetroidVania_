using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

	[Header("Layers")]
	public LayerMask groundLayer;

	[Space]

	public bool onGround;
	public bool onWall;
	public bool onRightWall;
	public bool onLeftWall;
	public int wallSide;
	bool flip;
	public float d;
	public Transform tr;
	public GameObject p1;
	public Rigidbody2D rb;

	[Space]

	[Header("Collision")]

	public float collisionRadius = 0.25f;
	public Vector2 bottomOffset, rightOffset, leftOffset;
	private Color debugCollisionColor = Color.red;

	// Start is called before the first frame update
	void Start()
	{
		p1 = GameObject.FindGameObjectWithTag("Player");
		
		tr = gameObject.transform;
		rb = gameObject.GetComponent<Rigidbody2D>();
		
	}

	// Update is called once per frame
	void Update()
	{
		Transform pT;
		pT = p1.GetComponent<Transform>();

		d = Vector2.Distance(pT.position, transform.position);

		onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
		onWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer)
			|| Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);

		onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer);
		onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);

		wallSide = onRightWall ? -1 : 1;

		if (tr.position.x > p1.transform.position.x && !flip)
		{
			
			Flip();
		}
		else if (tr.position.x < p1.transform.position.x && flip)
		{
			
			Flip();
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;

		var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset };
		
		Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
		Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
		Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);

		
	}

	
	public void Flip()
	{
		flip = !flip;
		tr.transform.localScale = new Vector2(tr.transform.localScale.x * -1, tr.transform.localScale.y);
	}
}
