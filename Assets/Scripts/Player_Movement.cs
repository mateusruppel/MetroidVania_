using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using TMPro;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
	#region variables

	AnimationSetter animSet;
	public List<GameObject> playerItens;
	public ItemInterface item;
	private Collision coll;	
	public Rigidbody2D rb;
	private Animator anim;
	public Inputs input;
	PlayerHealth PlayerHealth;
	public float speed = 10, jumpForce = 50, slideSpeed = 5, wallJumpLerp = 10, dashSpeed = 20;
	float a = 1f, b = 3;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	public float x, y;
	public int side = 1;
	Vector2 dir;
	[Space]
	[Header("Booleans")]
	public bool canMove,canFlip, sword,attack, jump, doublejump, jumpPress, isFlip, falling, wallGrab, wallJumped, wallSlide, isDashing,isPause;
	private bool groundTouch;
	private bool hasDashed;
	[Space]
	[Header("Particles")]
	public ParticleSystem dashParticle;
	public ParticleSystem jumpParticle;
	public ParticleSystem wallJumpParticle;
	public ParticleSystem slideParticle;
	TextMeshProUGUI tm, currentItemAmountText;
	public GameObject itemTxtMeshPro;
	Damager damager;
	public GameObject inventoryObj;
	Inventory inventory;

	//Player status
	public bool poisoned = false, lifeIsNotFull = false;
	#endregion


	public PlayerHealth GetPlayerHealth() => PlayerHealth;

	public void Heal(float hp) => PlayerHealth.HealPlayer(hp);


	void Awake()
	{
		
		input = new Inputs();
		tm = GetComponentInChildren<TextMeshProUGUI>();
		PlayerHealth = GetComponent<PlayerHealth>();
		inventoryObj = Instantiate(inventoryObj);
		anim = GetComponent<Animator>();
		coll = GetComponent<Collision>();
		damager = GetComponent<Damager>();
		rb = GetComponent<Rigidbody2D>();		
		inventory = inventoryObj.GetComponent<Inventory>();

	}

	void Start()
	{
		sword = false;

		#region set texts and events

		currentItemAmountText = itemTxtMeshPro.GetComponent<TextMeshProUGUI>();
		currentItemAmountText.SetText((item.itemAmount).ToString());
		item.deleteCallback = () => Debug.Log("Item esgotado");
		item.UseHandlerAddListener(() => { currentItemAmountText.SetText((item.itemAmount).ToString()); });
		#endregion

		#region Load data
		inventory.LoadInventory(playerItens);
		#endregion

        #region inputs

        input.Player.UseItem.performed += a => {
			item.UseItem(() =>
			{
				if (PlayerHealth.currentHealth < PlayerHealth.maxHealth) return true;
				else return false;
			});
		};

		input.Player.Jump.performed += ctx => jump = true;
		input.Player.Jump.canceled += ctx => jump = false;
	 	//atack 
	///	input.Player.attack.triggered += ctx => attack = true;
	 //	input.Player.attack.started += ctx => attack = true;
		
		input.Player.Inventory.performed += x => { inventory.GetComponent<Inventory>().OpenCloseInventory(); };
		
        #endregion
    }

	void FixedUpdate()
	{
		if (!isPause)
		{
			
			
			dir = new Vector2(x, y);

			Walk(dir);
			tm.SetText(PlayerHealth.currentHealth.ToString());

			if (falling && !doublejump)
			{
				rb.gravityScale = 6;
				if (jump && !coll.onGround && !coll.onWall)
				{
					Jump(Vector2.up, false);
					doublejump = true;
				}
			}

			else rb.gravityScale = 5;

			if (sword)
			{
				anim.SetLayerWeight(0, 0);
				anim.SetLayerWeight(1, 1);
			}

			else
			{
				anim.SetLayerWeight(0, 1);
				anim.SetLayerWeight(1, 0);
			}


			damager.playerIsAttacking = attack;
			anim.SetBool("attack",attack);
			
		}
	}


	// Update is called once per frame
	void Update()
	{
		if (isPause) Time.timeScale = 0;
		else Time.timeScale = 1;
		if (!isPause)
		{



			if (coll.onGround || coll.onWall) falling = false;
			else if (!coll.onGround && !jump) falling = true;
			//else if (!jump) falling = true;

			if (rb.velocity.y < 0)
			{
				rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
			}


			if (wallGrab && !isDashing)
			{
				rb.gravityScale = 0;
				if (x > .2f || x < -.2f)
					rb.velocity = new Vector2(rb.velocity.x, 0);

				float speedModifier = y > 0 ? .5f : 1;

				rb.velocity = new Vector2(rb.velocity.x, y * (speed * speedModifier));
			}


			if (coll.onWall && !coll.onGround)
			{
				if (x != 0 && !wallGrab)
				{
					wallJumped = false;
					wallSlide = true;
					WallSlide();
				}
			}

			if (!coll.onWall || coll.onGround) wallSlide = false;

			if (jump)
			{


				rb.gravityScale = 10f;
				if (coll.onGround && !jumpPress)
					Jump(Vector2.up, false);

				if (coll.onWall && !coll.onGround && !jumpPress)
				{
					WallJump();

				}
				jumpPress = true;
			}

			if (!jump)
			{
				rb.gravityScale = 15f;
				jumpPress = false;
			}


			if (wallGrab || wallSlide || !canMove)
				return;

			if (side == -1 && coll.onRightWall)
			{
				side = 1;
				Flip();
			}

			if (side == 1 && coll.onLeftWall)
			{
				side = -1;
				Flip();
			}

			if (!coll.onWall)
			{

				if (x > 0 && side == -1 && canFlip)
				{
					side = 1;
					Flip();
				}
				if (x < 0 && side == 1 && canFlip)
				{
					side = -1;
					Flip();
				}
			}

			if (coll.onWall || coll.onGround)
			{

				doublejump = false;
			}

			

		}
	}



	void SetItem(ItemInterface item)
    {
		if (item.isConsumable())
        {
			currentItemAmountText.gameObject.SetActive(true);
			item.UseHandlerAddListener(() => { currentItemAmountText.SetText((item.itemAmount).ToString()); });
		}
		if(item.getType() == ItemCategories.ItensTypes.healthPotion)
        {
			input.Player.UseItem.performed += a => {
				item.UseItem(() =>
				{
					if (PlayerHealth.currentHealth < PlayerHealth.maxHealth) return true;
					else return false;
				});
			};
		}

	}

	private void OnEnable()
	{
		input.Enable();
	}

	private void OnDisable()
	{
		input.Disable();
	}


	private void WallJump()
	{
		StopCoroutine(DisableMovement(0));
		StartCoroutine(DisableMovement(.1f));
		Vector2 wallDir = coll.onRightWall ? Vector2.left : Vector2.right;
		Jump((Vector2.up / a + wallDir / b), true);
		wallJumped = true;
	}

	private void WallSlide()
	{
		if (coll.wallSide != side )
			//Flip();
		if (!canMove)
			return;

	
		bool pushingWall = false;
		if ((rb.velocity.x > 0 && coll.onRightWall) || (rb.velocity.x < 0 && coll.onLeftWall))
		{
			pushingWall = true;
		}
		float push = pushingWall ? 0 : rb.velocity.x;

		rb.velocity = new Vector2(push, -slideSpeed);
	}

	private void Walk(Vector2 dir)
	{
		if (!canMove)
			return;

		if (wallGrab)
			return;

		if (!wallJumped)
		{
			rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
		}
		else
		{
			rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), wallJumpLerp * Time.deltaTime);
		}
	}

	private void Jump(Vector2 dir, bool wall)
	{
		slideParticle.transform.parent.localScale = new Vector3(ParticleSide(), 1, 1);
		ParticleSystem particle = wall ? wallJumpParticle : jumpParticle;

		rb.velocity = new Vector2(rb.velocity.x, 0);
		rb.velocity += dir * jumpForce;

		particle.Play();
	}

	IEnumerator DisableMovement(float time)
	{
		canMove = false;
		yield return new WaitForSeconds(time);
		canMove = true;
	}

	void RigidbodyDrag(float x)
	{
		rb.drag = x;
	}

	void WallParticle(float vertical)
	{
		var main = slideParticle.main;

		if (wallSlide || (wallGrab && vertical < 0))
		{
			slideParticle.transform.parent.localScale = new Vector3(ParticleSide(), 1, 1);
			main.startColor = Color.white;
		}
		else
		{
			main.startColor = Color.clear;
		}
	}

	int ParticleSide()
	{
		int particleSide = coll.onRightWall ? 1 : -1;
		return particleSide;
	}

	public void SetMov(InputAction.CallbackContext ctx)
	{
		x = ctx.ReadValue<float>();
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Damageable damageable = other.GetComponent<Damageable>();
		if (damageable != null)
		{

			if (attack) damager.DoDamage(damageable);
			//if (player && ) 
		}
	}

	protected void SetSword() => sword = !sword;
	protected void SetPause() => isPause= !isPause;
	protected void Flip() => transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
	
}
