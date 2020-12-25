///<summary>
/// Handles death of player and enemies
///</summary>
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

    /// <summary>
    /// Stops time, shows game over screen
    /// </summary>
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

    /// <summary>
    /// Gets show many enemies are dead
    /// </summary>
    /// <returns>The number of killed enemies</returns>
    public int GetEnemyCount()
    {
        return enemyCount;
    }

    /// <summary>
    /// Increases emeny kill count after killing an enemy
    /// </summary>
    public void IncreaseEnemyCount()
    {
        enemyCount++;
    }

}
