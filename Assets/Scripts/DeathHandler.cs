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
    SceneLoader scene;
    

    void Start()
    {
        scene = FindObjectOfType<SceneLoader>();
    }

    /// <summary>
    /// Stops time, shows game over screen
    /// </summary>
    public void HandleDeath()
    {
        scene.GameOver();
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
