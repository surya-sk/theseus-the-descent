using UnityEngine;

public class DeactivateObject : MonoBehaviour, ISaveable
{
    public GameObject targetObject;
    bool deactivated = false;

    public object CaptureState()
    {
        return deactivated;
    }

    public void RestoreState(object state)
    {
        deactivated = (bool)state;
        if(deactivated)
        {
            Deactivate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            deactivated = true;
            Deactivate();
        }
    }

    private void Deactivate()
    {
        targetObject.SetActive(false);
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
