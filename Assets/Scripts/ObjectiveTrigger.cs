using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Updates the objective on trigger
/// </summary>
public class ObjectiveTrigger : MonoBehaviour
{
    bool isFinished = false;
    [SerializeField] string objective;
    [SerializeField] TextMeshProUGUI objectiveText;

    private void OnTriggerEnter(Collider other)
    {
        objectiveText.text = objective;
    }

    private void OnTriggerExit(Collider other)
    {
        isFinished = true;
        Destroy(gameObject);
    }
}
