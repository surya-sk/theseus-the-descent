using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] GameObject activeObjecitve;
    [SerializeField] string soundName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(activeObjecitve.GetComponent<BoxCollider>().enabled)
            {
                FindObjectOfType<AudioManager>().Play(soundName);
            }
        }
    }
}
