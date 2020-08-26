///<summary>
///Script that trigger that battery pickup object when triggered 
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float angleIntensity = 90f;
    [SerializeField] float lightIntensity = 10f;
    [SerializeField] AudioClip pickupClip;

    /// <summary>
    /// Resets the angle and intesity and destroys the battery pickup object when the collider is triggered by the player
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(pickupClip, gameObject.transform.position);
            other.GetComponentInChildren<Torchlight>().ResetLightAngle(angleIntensity);
            other.GetComponentInChildren<Torchlight>().ResetLightIntensity(lightIntensity);
            //Destroy(gameObject);
        }
    }
}

