///<summary>
///This script controls the behavior of Ammo
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlots[] slots; //the thing that hold the ammo. In this game, the player
    [System.Serializable] //serialized field but for a whole class

    ///<summary>
    ///A class to make AmmoSlots an object to allow for more customization for each weapon
    ///</summary>
    private class AmmoSlots
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    /// <summary>
    /// Returns the amount of ammo left
    /// </summary>
    /// <param name="ammoType"></param>
    /// <returns>an int representing the <see cref="ammoAmount"/></returns>
    public int GetAmmoAmount(AmmoType ammoType)
    {
        return GetAmmoSlots(ammoType).ammoAmount;
    }

    /// <summary>
    /// Reduces ammo of the specified type by 1 when called
    /// </summary>
    /// <param name="ammoType"></param>
    public void ReduceCurrAmmo(AmmoType ammoType)
    {
        GetAmmoSlots(ammoType).ammoAmount--;
    }

    public void IncreaseCurrAmmo(AmmoType ammoType, int ammoIncrement)
    {
        GetAmmoSlots(ammoType).ammoAmount += ammoIncrement;
    }

    /// <summary>
    /// Returns the ammoSlot (player) if its ammoType matches the given ammoType
    /// </summary>
    /// <param name="ammoType"></param>
    /// <returns>AmmoSlots</returns>
    private AmmoSlots GetAmmoSlots(AmmoType ammoType)
    {
        foreach(AmmoSlots slot in slots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
