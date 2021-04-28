///
///<summary>
///The script that enables the player to switch weapons. The input is either the number keys or the scroll wheel
///</summary>
///
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField]int currWeaponIndex = 0;
    bool[] weaponEnabled = new bool[4];
    //int numWeapons = 0;

    void Start()
    {
        MakeWeaponActive();
    }

    private void Update()
    {
        WeaponAtIndexEnabled(3);
        int prevWeaponIndex = currWeaponIndex;
        TakeControllerInput();
        TakeKeyInput();
        TakeMouseScroll();
        if (prevWeaponIndex != currWeaponIndex)
        {
            MakeWeaponActive();
        }
    }

    /// <summary>
    /// Enables the weapon at the given index when picked up
    /// </summary>
    /// <param name="index"></param>
    public void WeaponAtIndexEnabled(int index)
    {
        weaponEnabled[index] = true;
    }

    /// <summary>
    /// makes the weapon with the current index active. Goes through the list of weapons, and sets 
    /// the weapon with the current index active and the rest to inactive 
    /// </summary>
    private void MakeWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currWeaponIndex && weaponEnabled[weaponIndex])
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    /// <summary>
    /// Takes keyboard inputs from the player. Assigned each key to a weapon index
    /// </summary>
    private void TakeKeyInput()
    {
        KeyCode[] keyCodes = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                currWeaponIndex = i;
            }
        }
    }

    /// <summary>
    /// Takes controller inputs from the player. Assigned each key to a weapon index
    /// </summary>
    private void TakeControllerInput()

    {
        KeyCode[] keyCodes = { KeyCode.JoystickButton2, KeyCode.JoystickButton3, KeyCode.JoystickButton1, KeyCode.JoystickButton9 };
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                currWeaponIndex = i;
            }
        }
    }

    /// <summary>
    /// Switches the weapons upon scrolling of the mouse wheel
    /// Each if statement is for a direction of the scroll 
    /// </summary>
    private void TakeMouseScroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currWeaponIndex >= transform.childCount - 1)
            {
                currWeaponIndex = 0;
            }
            else
            {
                currWeaponIndex++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currWeaponIndex <= 0)
            {
                currWeaponIndex = transform.childCount - 1;
            }
            else
            {
                currWeaponIndex--;
            }
        }

    }
}
