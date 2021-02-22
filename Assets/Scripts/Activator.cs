using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Activates a game object according to the objecitve
/// </summary>
public class Activator : MonoBehaviour, ISaveable
{
    [SerializeField] GameObject objectToActivate;
    [SerializeField] GameObject activeObjective;
    bool activated;

    public object CaptureState()
    {
        return activated;
    }

    public void RestoreState(object state)
    {
        activated = (bool)state;
        if(activated)
        {
            objectToActivate.SetActive(true);
            activated = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(activeObjective.GetComponent<BoxCollider>().enabled)
            {
                objectToActivate.SetActive(true);
                activated = true;
            }
        }
    }
}
