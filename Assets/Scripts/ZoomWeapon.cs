///<summary>
///Zooms weapons that can be zoomed. 
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ZoomWeapon : MonoBehaviour
{
    [SerializeField] Camera fpCamera;
    [SerializeField] RigidbodyFirstPersonController fpController; //the player
    [SerializeField] float zoomedOutFOV = 60;
    [SerializeField] float zoomedInFOV = 20;
    [SerializeField] float zoomedInMouseSensitivity = 0.5f;
    [SerializeField] float zoomedOutMouseSensitivity = 2;
    bool isZoomedIn = false;

    /// <summary>
    /// To fix the error where when zoomed in and the player switches weapon, the weapons that's switched to is also zoomed in
    /// irrespective of whether it has this script (aka can be zoomed in) 
    /// Might not be the best solution, subject to change 
    /// </summary>
    private void OnDisable()
    {
        ZoomOut();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) || Mathf.Round(Input.GetAxisRaw("Fire2")) < 0)
        {
            if(isZoomedIn == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    /// <summary>
    /// zooms in, ie, sets the camera FOV to zommedInFOV
    /// </summary>
    private void ZoomIn()
    {
        isZoomedIn = true;
        fpCamera.fieldOfView = zoomedInFOV;
        fpController.mouseLook.XSensitivity = zoomedInMouseSensitivity;
        fpController.mouseLook.YSensitivity = zoomedInMouseSensitivity;
    }

    /// <summary>
    /// zooms out, ie, sets the camera FOV to zommedOutFOV
    /// </summary>
    private void ZoomOut()
    {
        isZoomedIn = false;
        fpCamera.fieldOfView = zoomedOutFOV;
        fpController.mouseLook.XSensitivity = zoomedOutMouseSensitivity;
        fpController.mouseLook.YSensitivity = zoomedOutMouseSensitivity;
    }
}
