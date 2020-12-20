using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathHandler : MonoBehaviour
{
    int enemyCount = 0;
    [SerializeField] Canvas gameOverScreen;

    void Start()
    {
        gameOverScreen.enabled = false;
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

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public void IncreaseEnemyCount()
    {
        enemyCount++;
    }

}
