///<summary>
///Script that controls the enemy behavior when they attack the player
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target; //using PlayerHealth as target to make it easier to reduce health 
    [SerializeField] float damage = 40f;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    /// <summary>
    /// Decreases the player health by damage amount 
    /// </summary>
    public void AttackEvent()
    {
        if(target == null)
        {
            return;
        }
        target.PlayerDamage(damage);
        Debug.Log("I've hit you!");
    }
   
}
