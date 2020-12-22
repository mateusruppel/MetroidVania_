using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public bool jump;
    bool flip;
    Vector2 vel;
    public float x;
    public Transform tr;
    public GameObject p1;
    public Rigidbody2D rb;
    private EnemyCollision coll;
    public int GroundCount = 0;
    public int timesTojump;
    Animator anim;
    public float nextTimetoCount = 0f; 
    public float countRate = 20f; 


    void Start()
    {
        
        tr = gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        coll = gameObject.GetComponent<EnemyCollision>();
        GroundCount = 0;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       bouncing();
    }

    private void bouncing()
    {
        if(coll.onGround && Time.time >= nextTimetoCount)
        {
            nextTimetoCount = Time.time + 1f / countRate;
            GroundCount++;
            Jump();
        }

        if (GroundCount > timesTojump) GroundCount = 1;
    }

    private void Jump()
    {
        vel = new Vector2(x, 25);
        rb.velocity = vel;
    }
}


