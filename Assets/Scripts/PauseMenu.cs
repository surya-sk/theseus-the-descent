///<summary>
///The pause menu that can be called any time during the game
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;

    public void Start()
    {
        pauseCanvas.enabled = false;
    }

    private void Update()
    {
        PauseOverlay();
    }

    /// <summary>
    /// Show pause menu when pause button is clicked
    /// </summary>
    private void PauseOverlay()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Esc"))
        {
            if(pauseCanvas.enabled == false)
            {
                pauseCanvas.enabled = true;
                Time.timeScale = 0;
                FindObjectOfType<SwitchWeapon>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                AudioListener.pause = true;
            }
            else
            {
                pauseCanvas.enabled = false;
                Time.timeScale = 1;
                FindObjectOfType<SwitchWeapon>().enabled = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;
                AudioListener.pause = false;
            }
        }
    }

}
