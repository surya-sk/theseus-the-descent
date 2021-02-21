using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Canvas hintCanvas;

    private void Start()
    {
        hintCanvas.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        hintCanvas.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        hintCanvas.enabled = false;
    }
}
