///<summary>
///Dictates the functionality of the player's health
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100;
    bool isDead = false;

    /// <summary>
    /// decreases the player health by the given damage
    /// calls the death handler when health is too low 
    /// </summary>
    /// <param name="damage"></param>
    public void PlayerDamage(float damage)
    {
        health -= damage;
        if(health<=0)
        {
            isDead = true;
            GetComponent<DeathHandler>().HandleDeath();
            print("I'm dead");
        }
    }

    public bool PlayerIsDead()
    {
        return isDead;
    }
}


