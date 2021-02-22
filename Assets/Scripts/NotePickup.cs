using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotePickup : MonoBehaviour
{
    [SerializeField] Canvas promptCanvas;
    [SerializeField] TextMeshProUGUI promptText;
    [SerializeField] Canvas noteCanvas;
    [SerializeField] TextMeshProUGUI objectiveText;
    bool isNearNote;
    bool isReadingNote;

    private void Start()
    {
        promptCanvas.enabled = false;
        promptText.text = "Press LT or right click to interact";
        isNearNote = false;
        isReadingNote = false;
        noteCanvas.enabled = false;
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
            promptText.text = "Press LT or right click to exit";
            noteCanvas.enabled = true;
            Time.timeScale = 0;
            if(Input.GetMouseButtonDown(1) || Mathf.Round(Input.GetAxisRaw("Fire2")) < 0)
            {
                isReadingNote = false;
                noteCanvas.enabled = false;
                Time.timeScale = 1;
                promptText.text = "Press LT or right click to interact";
                objectiveText.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            promptCanvas.enabled = true;
            isNearNote = true;
            objectiveText.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            promptCanvas.enabled = false;
            isNearNote = false;
        }
    }
}
