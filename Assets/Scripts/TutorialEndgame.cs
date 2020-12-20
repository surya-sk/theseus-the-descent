using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialEndgame : MonoBehaviour
{
    [SerializeField] Canvas gameOverScreen;
    int enemyCount = 0;
    [SerializeField] TextMeshProUGUI enemyCountText;
    [SerializeField] Canvas winScreen;
    DeathHandler deathHandler;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.enabled = false;
        winScreen.enabled = false;
        deathHandler = FindObjectOfType<DeathHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        print(enemyCount);
        enemyCount = deathHandler.GetEnemyCount();
    }
    private void DisplayEnemyCount()
    {
        enemyCountText.text = "Kill Count: " + enemyCount;
    }
}
