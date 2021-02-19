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
    [SerializeField] GameObject nextObjective;
    [SerializeField] GameObject firstObjective;
    [SerializeField] AudioClip pickupClip;

    /// <summary>
    /// Sets the objective active, and activates the next one 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        objective = objectiveString;
        objectiveText.text = objective;
        AudioSource.PlayClipAtPoint(pickupClip, gameObject.transform.position);
        isFinished = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        if(nextObjective != null)
        {
            nextObjective.GetComponent<BoxCollider>().enabled = true;
        }
        ObjectiveManager.GetInstance().SetCurrentObjective(objective);
    }

    public object CaptureState()
    {
        if(nextObjective == null)
        {
            return null;
        }
        if(ObjectiveManager.GetInstance().GetCurrentObjective().Equals(objective))
        {
            return $"{isFinished},{objective}";
        }
        else
        {
            return null;
        }
    }

    public void RestoreState(object state)
    {
        if(!objectiveText.text.Equals("Go to the office"))
        {
            firstObjective.SetActive(false);
        }
        string result = (string)state;
        if(result == null)
        {
            return;
        }
        string[] splitResult = result.Split(',');
        isFinished = Convert.ToBoolean(splitResult[0]);
        objective = splitResult[1];
        ObjectiveManager.GetInstance().SetCurrentObjective(objective);
        if (isFinished)
        {
            if (nextObjective != null)
            {
                nextObjective.GetComponent<BoxCollider>().enabled = true;
            }
            objectiveText.text = objective;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
