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
