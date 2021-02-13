﻿using System.Collections;
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
    [SerializeField] GameObject linkedObjective;

    private void OnTriggerEnter(Collider other)
    {
        objective = objectiveString;
        objectiveText.text = objective;
        isFinished = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        linkedObjective.GetComponent<BoxCollider>().enabled = true;
        ObjectiveManager.GetInstance().SetCurrentObjective(objective);
    }

    public object CaptureState()
    {
        print($"Saving {objective} and {isFinished}");
        print($"Current objective is {ObjectiveManager.GetInstance().GetCurrentObjective()}");
        if(!ObjectiveManager.GetInstance().GetCurrentObjective().Equals(objective))
        {
            print("Not this one " + objective);
            return null;
        }
        else
        {
            return $"{isFinished},{objective}";
        }
    }

    public void RestoreState(object state)
    {
        string result = (string)state;
        if(result == null)
        {
            return;
        }
        string[] splitResult = result.Split(',');
        isFinished = Convert.ToBoolean(splitResult[0]);
        objective = splitResult[1];
        ObjectiveManager.GetInstance().SetCurrentObjective(objective);
        print($"Loading {objective}");
        if (isFinished)
        {
            if (linkedObjective != null)
            {
                linkedObjective.GetComponent<BoxCollider>().enabled = true;
            }
            objectiveText.text = objective;
            print(objectiveText.text);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
