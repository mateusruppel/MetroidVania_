using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{

    public float damage;
    public bool playerIsAttacking;
    public bool destroyOnDamage;
    public bool player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damageable damageable = other.GetComponent<Damageable>();
        if(damageable != null)
        {
            if(player)
            if(!player) DoDamage(damageable);
            //if (player && ) 
        }
    }

    public void DoDamage(Damageable damageable)    
    {
        
        damageable.TakeDamage(damage);
        if (destroyOnDamage)
            Destroy(gameObject);
       
    }

    
}
