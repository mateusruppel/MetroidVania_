using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilloBounce : StateMachineBehaviour
{
	bool flip;
    public Vector2 vel;
	float x;
    public Transform tr;
	public GameObject p1;
    public Rigidbody2D rb;
	private EnemyCollision coll;
	public int groundedCount = 0;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		p1 = GameObject.FindGameObjectWithTag("Player");
        tr = animator.gameObject.transform;
        rb = animator.gameObject.GetComponent<Rigidbody2D>();
		coll = animator.gameObject.GetComponent<EnemyCollision>();
	}

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		if (coll.onGround)
        {
            groundedCount += 1;  
			if(groundedCount == 1)
			{
				if (tr.position.x > p1.transform.position.x)
				{
					x = -5;					
				}
				else if (tr.position.x < p1.transform.position.x)
				{
					x = 5;					
				}
				vel = new Vector2(x, 25);
			}
			animator.SetInteger("GroundedCount", groundedCount);
            rb.velocity = vel;
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.velocity = Vector2.zero;
        groundedCount = 0;
		animator.SetInteger("GroundedCount", groundedCount);
	}
}
