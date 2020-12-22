using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilloBounce : StateMachineBehaviour
{
	bool jump;	
    public Vector2 vel;
	public float x;
    public Transform tr;
	public GameObject p1;
    public Rigidbody2D rb;
	private EnemyCollision coll;
	public int GroundCount = 0;
    public int timesTojump;
    public float nextTimetoCount = 0f;
    public float countRate = 20f;
    [SerializeField] bool P_right;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		p1 = GameObject.FindGameObjectWithTag("Player");
        tr = animator.gameObject.transform;
        rb = animator.gameObject.GetComponent<Rigidbody2D>();
		coll = animator.gameObject.GetComponent<EnemyCollision>();



        if (tr.position.x < p1.transform.position.x) P_right = true;
        else if (tr.position.x > p1.transform.position.x) P_right = false;

        if (GroundCount < 1 && P_right == true) invert(-1);
        else if(GroundCount < 1 && P_right == true) invert(1);

        
    }

	
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		

		animator.SetInteger("GroundedCount", GroundCount);





        if (tr.position.x > p1.transform.position.x) P_right = true;
        else if (tr.position.x < p1.transform.position.x) P_right = false;

        if (GroundCount < 1 && P_right == true) invert(-1);
        else if (GroundCount < 1 && P_right == false) invert(1);
        

        
        bouncing();

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
	}

    private void bouncing()
    {
        if (coll.onGround && Time.time >= nextTimetoCount && GroundCount <= timesTojump)
        {
            nextTimetoCount = Time.time + 1f / countRate;
            GroundCount++;
            Jump();
        }

        if (GroundCount > timesTojump)
        {
            GroundCount = 0;
            rb.velocity = Vector2.zero;
        }
    }

    private void invert(int i)
    {
        x = Mathf.Abs(x);
        x *= i;       
    }


    private void Jump()
    {
        vel = new Vector2(x, 25);
        rb.velocity = vel;
    }
}
