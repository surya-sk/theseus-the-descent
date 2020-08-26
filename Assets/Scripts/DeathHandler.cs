using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverScreen;
    int enemyCount = 0;
    [SerializeField] TextMeshProUGUI enemyCountText;
    [SerializeField] Canvas winScreen;

    public void Start()
    {
        gameOverScreen.enabled = false;
        winScreen.enabled = false;
    }

    private void Update()
    {
        DisplayEnemyCount();
        if (enemyCount == 15)
        {
            EnableWinScreen();
            if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.Escape))
            {
                winScreen.enabled = false;
                Time.timeScale = 1;
                FindObjectOfType<SwitchWeapon>().enabled = true;
                Cursor.visible = false;
                AudioListener.pause = false;
            }
        }
    }

    public void HandleDeath()
    {
        gameOverScreen.enabled = true;
        Time.timeScale = 0;
        AudioListener.pause = true;
        FindObjectOfType<SwitchWeapon>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioListener.pause = true;
    }



    public void IncreaseEnemyCount()
    {
        enemyCount++;
    }

    private void EnableWinScreen()
    {
        winScreen.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<SwitchWeapon>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioListener.pause = true;
    }

    private void DisplayEnemyCount()
    {
        enemyCountText.text = "Kill Count: " + enemyCount;
    }

}
