///<summary>
/// Handles the tutorial end game : either win or lose
///</summary>
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialEndgame : MonoBehaviour
{
    int enemyCount = 0;
    [SerializeField] TextMeshProUGUI enemyCountText;
    [SerializeField] Canvas winScreen;
    DeathHandler deathHandler;
    bool continuePlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        winScreen.enabled = false;
        deathHandler = FindObjectOfType<DeathHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        print(enemyCount);
        enemyCount = deathHandler.GetEnemyCount();
        DisplayEnemyCount();
        EndGame();
    }

    /// <summary>
    /// Ends the game if enough enemies are killed
    /// while giving the player the option to continue playing
    /// </summary>
    private void EndGame()
    {
        if (enemyCount == 8)
        {
            if (!continuePlaying) EnableWinScreen();
            if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.B))
            {
                continuePlaying = true;
                winScreen.enabled = false;
                Time.timeScale = 1;
                FindObjectOfType<SwitchWeapon>().enabled = true;
                Cursor.visible = false;
                AudioListener.pause = false;
            }
        }
    }

    /// <summary>
    /// Enables the win screen
    /// </summary>
    private void EnableWinScreen()
    {
        winScreen.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<SwitchWeapon>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioListener.pause = true;
    }

    /// <summary>
    /// Displays the kill count on the screen
    /// </summary>
    private void DisplayEnemyCount()
    {
        enemyCountText.text = "Kill Count: " + enemyCount;
    }
}
