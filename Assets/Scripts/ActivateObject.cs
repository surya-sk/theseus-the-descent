using UnityEngine;

public class ActivateObject : MonoBehaviour, ISaveable
{
    public GameObject targetObject;
    bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            activated = true;
            Activate();
        }
    }

    private void Activate()
    {
        targetObject.SetActive(true);
        gameObject.GetComponent<Collider>().enabled = false;
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
            Activate();
        }
    }
}
