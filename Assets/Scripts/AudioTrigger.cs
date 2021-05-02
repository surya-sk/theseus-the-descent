using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public GameObject activeObjecitve;
    public string soundName;
    public AudioManager audioManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(activeObjecitve.GetComponent<BoxCollider>().enabled)
            {
                audioManager.Play(soundName);
            }
        }
    }
}
