///<summary>
///Handles transition between scenes
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(3);
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
   
}
