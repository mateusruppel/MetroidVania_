using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

	[Header("Layers")]
	public LayerMask groundLayer;
	[SerializeField] Transform groundCheck;
	[Space]
	public bool canMove;
	public bool onGround;
	public bool onWall;
	public bool onRightWall;
	public bool onLeftWall;
	public int wallSide;
	bool flip;
	public Vector2 d;
	public Transform tr;
	public GameObject p1;
	public Rigidbody2D rb;
	public int groundedCount = 0;
	public Vector2 vel;
	Animator anim;
	float x;

	[Space]

	[Header("Collision")]

	public float collisionRadius = 0.25f;
	public Vector2 rightOffset, leftOffset;
	private Color debugCollisionColor = Color.red;

	// Start is called before the first frame update
	void Start()
	{
		p1 = GameObject.FindGameObjectWithTag("Player");
		anim = gameObject.GetComponent<Animator>();
		tr = gameObject.transform;
		rb = gameObject.GetComponent<Rigidbody2D>();
		

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		anim.SetBool("onground", onGround);
		

		if (p1 == null)
			return;
		if(p1 != null) p1.GetComponent<Transform>();
		d.x = p1.transform.position.x - transform.position.x;
		d.x = Mathf.Abs(d.x);
		d.y = p1.transform.position.y - transform.position.y;
		d.y = Mathf.Abs(d.y);
		//d = Vector2.Distance(pT.position, transform.position);

		onGround = Physics2D.OverlapCircle(groundCheck.position, collisionRadius, groundLayer);
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

		anim.SetFloat("distance_X", d.x);
		anim.SetFloat("distance_Y", d.y);
		if (d.x > 8.5 || d.y > 5) canMove = false;
		if (d.x < 8.5 && d.y < 5) canMove = true;
		anim.SetBool("canmove", canMove);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;

		var positions = new Vector2[] {  rightOffset, leftOffset };
		
		Gizmos.DrawWireSphere(groundCheck.position, collisionRadius);
		//Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
		//Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
		
		
	}

	
	public void Flip()
	{
		flip = !flip;
		tr.transform.localScale = new Vector2(tr.transform.localScale.x * -1, tr.transform.localScale.y);
	}


}
