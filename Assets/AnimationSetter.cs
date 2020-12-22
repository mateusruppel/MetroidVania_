using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationSetter : MonoBehaviour
{
	Player_Movement mov;
	PlayerCombat combat;
	Animator anim;
	Collision coll;
	float x, y;

	private void Awake()
	{
		mov = GetComponent<Player_Movement>();
		combat = GetComponent<PlayerCombat>();
		anim = GetComponent<Animator>();
		coll = GetComponent<Collision>();
	}

    void Update()
    {
       if (!mov.isPause)
		{
			x = mov.x;
			anim.SetFloat("Horizontal", x);
			if (x == 0) anim.SetInteger("Horizontal2", 0);
			else anim.SetInteger("Horizontal2", 1);
			anim.SetBool("onGround", coll.onGround);
			anim.SetBool("onWall", coll.onWall);
			anim.SetBool("jump", mov.jump);
			anim.SetBool("falling", mov.falling);
		}
	}
}
