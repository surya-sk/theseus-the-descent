using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

/// <summary>
/// Updates the objective on trigger
/// </summary>
public class ObjectiveTrigger : MonoBehaviour, ISaveable
{
    bool isFinished = false;
    string objective;
    public string objectiveString;
    public TextMeshProUGUI objectiveText;
    public GameObject nextObjective;
    public GameObject firstObjective;
    public AudioClip pickupClip;
    public SavingDemo savingDemo;

    /// <summary>
    /// Sets the objective active, and activates the next one 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            objective = objectiveString;
            objectiveText.text = objective;
            AudioSource.PlayClipAtPoint(pickupClip, other.gameObject.transform.position);
            isFinished = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            if (nextObjective != null)
            {
                nextObjective.GetComponent<BoxCollider>().enabled = true;
            }
            ObjectiveManager.GetInstance().SetCurrentObjective(objective);
            savingDemo.Save();
        }
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
