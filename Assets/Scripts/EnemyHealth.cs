///<summary>
///Handles Enemy health
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour, ISaveable
{
    [SerializeField] float damageCap = 100f; //damage capacity: decreases as damage is done
    bool isDead = false;

    /// <summary>
    ///  Enemy state
    /// </summary>
    /// <returns>Whether emeny is dead</returns>
    public bool EnemyIsDead()
    {
        return isDead;
    }
    
    /// <summary>
    /// Decrease enemy heath when damage has been taken
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="ammoType"></param>
    public void Damage(float damage, AmmoType ammoType)
    {
        BroadcastMessage("OnBeingHit");
        damageCap -= damage;
        if(isDead)
        {
            return;
        }
        if(damageCap<=5)
        {
            FindObjectOfType<DeathHandler>().IncreaseEnemyCount();
            isDead = true;
            if(ammoType == AmmoType.Shells)
            {
                GetComponent<Animator>().SetTrigger("DieBackwards");
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Die");
            }
        }
    }

    public object CaptureState()
    {
        return damageCap;
    }

    public void RestoreState(object state)
    {
        damageCap = (float)state;
        if(damageCap<=5)
        {
            FindObjectOfType<DeathHandler>().IncreaseEnemyCount();
            isDead = true;
            GetComponent<Animator>().SetTrigger("DieBackwards");
        }
    }
}
