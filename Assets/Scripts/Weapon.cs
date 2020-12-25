///<summary>
/// Handles the active weapon actions
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float range = 100f;
    [SerializeField] float weaponDamage = 30f;
    [SerializeField] ParticleSystem gunShotVFX;
    [SerializeField] GameObject impactVFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField]TextMeshProUGUI ammoText;
    [SerializeField] AudioClip clip;
    [SerializeField] float volume = 0.5f;

    bool isReadyToShoot = true;

    private void OnEnable()
    {
        isReadyToShoot = true;
    }

    void Update()
    {
        DisplayAmmoCount();
        if ((Input.GetMouseButtonDown(0) || Mathf.Round(Input.GetAxisRaw("Fire1")) > 0) && isReadyToShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    /// <summary>
    /// Shoot with the right ammo type
    /// </summary>
    /// <returns></returns>
    IEnumerator Shoot()
    {
        isReadyToShoot = false; 
        if(ammoSlot.GetAmmoAmount(ammoType)>0)
        {
            TriggerGunshotEffects();
            TriggerSFX();
            ProcessRaycast();
            ammoSlot.ReduceCurrAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        isReadyToShoot = true;
    }

    /// <summary>
    /// Detect what is being shot
    /// if enemy, deal damage
    /// </summary>
    private void ProcessRaycast()
    {
        RaycastHit tarObj; //Target object
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out tarObj, range))
        {
            Debug.Log("This time, the target is " + tarObj.transform.name);
            TriggerImpactEffects(tarObj);
            EnemyHealth enemy = tarObj.transform.GetComponent<EnemyHealth>();
            if (enemy == null)
            {
                return;
            }
            enemy.Damage(weaponDamage,ammoType);
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// show the gunshot effects
    /// </summary>
    private void TriggerGunshotEffects()
    {
        gunShotVFX.Play();
    }

    /// <summary>
    /// Display the number of bullets left
    /// </summary>
    private void DisplayAmmoCount()
    {
        int currAmmoCount = ammoSlot.GetAmmoAmount(ammoType);
        ammoText.text = currAmmoCount.ToString();
    }

    /// <summary>
    ///  Show the impact VFX
    /// </summary>
    /// <param name="raycastHit"></param>
    private void TriggerImpactEffects(RaycastHit raycastHit)
    {
        GameObject impactFXObject = Instantiate(impactVFX, raycastHit.point, Quaternion.LookRotation(raycastHit.normal));
        Destroy(impactFXObject, 0.1f);
    }

    /// <summary>
    /// Play the gunshot sound 
    /// </summary>
    private void TriggerSFX()
    {
        AudioSource.PlayClipAtPoint(clip, gameObject.transform.position, volume);
    }


 
}
