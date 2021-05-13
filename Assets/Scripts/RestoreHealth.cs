using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHealth : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        playerHealth.RestoreHealth();
    }
}
