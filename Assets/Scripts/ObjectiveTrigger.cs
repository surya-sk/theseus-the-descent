using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/// <summary>
/// Updates the objective on trigger
/// </summary>
public class ObjectiveTrigger : MonoBehaviour, ISaveable
{
    bool isFinished = false;
    string objective;
    [SerializeField] string objectiveString;
    [SerializeField] TextMeshProUGUI objectiveText;

    private void OnTriggerEnter(Collider other)
    {
        objective = objectiveString;
        objectiveText.text = objective;
        isFinished = true;
    }

    public object CaptureState()
    {
        print(objective + isFinished);
        return $"{isFinished},{objectiveString}";
    }

    public void RestoreState(object state)
    {
        string result = (string)state;
        print("Result is " + state);
        string[] splitResult = result.Split(',');
        isFinished = Convert.ToBoolean(splitResult[0]);
        objective = splitResult[1];
        if(isFinished)
        {
            objectiveText.text = objective;
            Destroy(gameObject);
        }
    }
}
