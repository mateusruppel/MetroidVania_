using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Usado para checar as condições do player e setá-las nos validadores de item
/// </summary>
public class CanUseItemConditions : MonoBehaviour
{
    Player_Movement player;
    public CanUseItemConditions(Player_Movement player_)
    {
        player = player_;
    }

    public bool LifeIsNotComplete(){
        if (player.GetPlayerHealth().currentHealth < player.GetPlayerHealth().maxHealth)return true;
		else return false;
	}

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
