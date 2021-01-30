using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotePickup : MonoBehaviour
{
    [SerializeField] Canvas promptCanvas;
    [SerializeField] TextMeshProUGUI promptText;
    bool isNearNote;
    bool isReadingNote;

    private void Start()
    {
        promptCanvas.enabled = false;
        promptText.text = "Press LT to interact";
        isNearNote = false;
        isReadingNote = false;
    }

    private void Update()
    {
        if(isNearNote && !isReadingNote)
        {
            if (Input.GetMouseButtonDown(1) || Mathf.Round(Input.GetAxisRaw("Fire2")) < 0)
            {
                isReadingNote = true;
            }
        }

        else if(isReadingNote)
        {
            promptText.text = "Press B to exit";
            if(Input.GetMouseButtonDown(1) || Mathf.Round(Input.GetAxisRaw("Fire2")) < 0)
            {
                isReadingNote = false;
                promptText.text = "Press LT to interact";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            promptCanvas.enabled = true;
            isNearNote = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            promptCanvas.enabled = false;
        }
    }
}
