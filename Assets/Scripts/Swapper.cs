using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A class that swaps the current object with a provided one when an objective is activated
/// </summary>
public class Swapper : MonoBehaviour, ISaveable
{
    [SerializeField] GameObject toSwap;
    [SerializeField] GameObject swapWith;
    [SerializeField] GameObject objectiveTrigger;
    [SerializeField] bool isTemp; 
    bool hasSwapped = false;

    public object CaptureState()
    {
        return hasSwapped;
    }

    public void RestoreState(object state)
    {
        hasSwapped = (bool)state;
        if(hasSwapped)
        {
            SwapObjects();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(objectiveTrigger.GetComponent<BoxCollider>().enabled)
        {
            SwapObjects();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(isTemp)
        {
            hasSwapped = false;
            swapWith.SetActive(false);
            toSwap.SetActive(true);
        }
    }

    private void SwapObjects()
    {
        hasSwapped = true;
        toSwap.SetActive(false);
        swapWith.SetActive(true);
    }
}
