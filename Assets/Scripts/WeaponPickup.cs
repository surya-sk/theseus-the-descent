using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour, ISaveable
{
    SwitchWeapon switchWeapon;
    string[] weaponTags = { "Pistol", "SMG", "Shotgun" };
    [SerializeField] AudioClip pickupClip;
    int pickedIndex = -1;


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
                    pickedIndex = i;
                    gameObject.transform.position = new Vector3(transform.position.x, -5, transform.position.z);
                }
            }
        }
    }

    public object CaptureState()
    {
        return pickedIndex;
    }

    public void RestoreState(object state)
    {
        pickedIndex = (int)state;
        switchWeapon.WeaponAtIndexEnabled(pickedIndex);
        if(pickedIndex != -1)
            Destroy(gameObject);
    }
}
