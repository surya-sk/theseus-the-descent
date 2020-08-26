///<summary>
///Enables the player to pick up ammo
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoIncrement = 5;
    [SerializeField] AmmoType ammoType;
    [SerializeField] AudioClip pickupSound;

    /// <summary>
    /// Increases ammo amount by 5 when player gets in contact with a visual ammo pickup
    /// </summary>
    /// <param name="collision">The ammo pickup</param>
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has reached the ammo");
            AudioSource.PlayClipAtPoint(pickupSound, gameObject.transform.position);
            FindObjectOfType<Ammo>().IncreaseCurrAmmo(ammoType, ammoIncrement);
            Destroy(gameObject);
        }
    }
}
