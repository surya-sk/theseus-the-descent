///<summary>
///A mono-functional class that saves player location
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ISaveable
{
    public object CaptureState()
    {
        print(transform.position);
        return new SerializableVector3(transform.position);
    }

    public void RestoreState(object state)
    {
        SerializableVector3 position = (SerializableVector3)state;
        //GetComponent<NavMeshAgent>().enabled = false;
        transform.position = position.ConvertToVector();
    }

}
