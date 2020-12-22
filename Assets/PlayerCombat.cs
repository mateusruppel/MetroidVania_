using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public Inputs input;
    public bool attack;
    Player_Movement player_Movement;
    public LayerMask EnemyLayers;

    // Start is called before the first frame update
    void Awake()
    {
        input = new Inputs();
        player_Movement = GetComponent<Player_Movement>();
    }

    void Start()
    {

        //input.Player.attack.canceled += ctx => attack = false;
    }

    // Update is called once per frame
    void Update()
    {

        



    }

    public void Attack()
    {
        animator.SetTrigger("attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("a");
        }

        
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
