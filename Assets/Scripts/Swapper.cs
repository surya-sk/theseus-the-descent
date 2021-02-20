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
       if(other.gameObject.tag == "Player")
        {
            if (objectiveTrigger.GetComponent<BoxCollider>().enabled || gameObject.tag == "Toy")
            {
                SwapObjects();
            }
        }
    }

    private void SwapObjects()
    {
        hasSwapped = true;
        toSwap.SetActive(false);
        swapWith.SetActive(true);
    }
}
