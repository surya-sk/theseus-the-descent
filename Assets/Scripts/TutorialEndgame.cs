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
        if (enemyCount == 2)
        {
            EnableWinScreen();
            if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.B))
            {
                winScreen.enabled = false;
                Time.timeScale = 1;
                FindObjectOfType<SwitchWeapon>().enabled = true;
                Cursor.visible = false;
                AudioListener.pause = false;
            }
        }
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
