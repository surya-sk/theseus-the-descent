using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A class that swaps the current object with a provided one when an objective is activated
/// </summary>
public class Swapper : MonoBehaviour
{
    [SerializeField] GameObject swapWith;
    [SerializeField] GameObject objectiveTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(objectiveTrigger.GetComponent<BoxCollider>().enabled)
        {
            Destroy(gameObject);
            swapWith.SetActive(true);
        }
    }
}
