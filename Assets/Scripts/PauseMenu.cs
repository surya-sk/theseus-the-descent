///<summary>
///The pause menu that can be called any time during the game
///</summary>
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject otherUI;

    public static bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Esc"))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Show pause menu when pause button is clicked
    /// </summary>
    //private void PauseOverlay()
    //{
    //    if(Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Esc"))
    //    {
    //        if(pauseCanvas.enabled == false)
    //        {
    //            pauseCanvas.enabled = true;
    //            Time.timeScale = 0;
    //            FindObjectOfType<SwitchWeapon>().enabled = false;
    //            Cursor.visible = false;
    //            AudioListener.pause = true;
    //        }
    //        else
    //        {
    //            pauseCanvas.enabled = false;
    //            Time.timeScale = 1;
    //            FindObjectOfType<SwitchWeapon>().enabled = true;
    //            Cursor.lockState = CursorLockMode.None;
    //            Cursor.visible = false;
    //            AudioListener.pause = false;
    //        }
    //    }
    //}

    void Pause()
    {
        otherUI.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
        isPaused = true;
    }

    public void Resume()
    {
        otherUI.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        isPaused = false;
    }

}
