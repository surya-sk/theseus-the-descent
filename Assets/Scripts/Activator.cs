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

    private void Update()
    {
        if (activated)
        {
            print(objectToActivate.name);
            objectToActivate.SetActive(true);
        }
    }

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
                activated = true;
            }
        }
    }
}
