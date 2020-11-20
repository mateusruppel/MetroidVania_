using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public void Heal(float hp)
    {
        try
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            p.GetComponent<Player_Movement>().Heal(hp);
        }
        catch { Debug.Log("error"); }
    }
}
