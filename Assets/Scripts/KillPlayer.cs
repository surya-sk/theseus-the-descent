using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Kills the player instantly when near object.
/// Used for fall damage in Chapter 3
/// </summary>
public class KillPlayer : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        playerHealth.PlayerDamage(100);
    }
}
