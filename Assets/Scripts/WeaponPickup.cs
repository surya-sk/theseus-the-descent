using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    SwitchWeapon switchWeapon;
    string[] weaponTags = { "Pistol", "SMG", "Shotgun" };
    [SerializeField] AudioClip pickupClip;


    private void Start()
    {
        switchWeapon = FindObjectOfType<SwitchWeapon>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            for(int i = 0; i < weaponTags.Length; i++)
            {
                if(gameObject.tag == weaponTags[i])
                {
                    AudioSource.PlayClipAtPoint(pickupClip, gameObject.transform.position);
                    switchWeapon.WeaponAtIndexEnabled(i);
                    Destroy(gameObject);
                }
            }
        }
    }
}
