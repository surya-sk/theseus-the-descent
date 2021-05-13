///<summary>
///Handles transition between scenes
///</summary>
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "Chapter 2.sav")))
        {
            Chapter3();
        }
        else if (File.Exists(Path.Combine(Application.persistentDataPath, "Chapter 2.sav")))
        {
            Chapter2();
         }
        else
        {
            Chapter1();
        }
    }
    public void Tutorial()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Chapter1()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Chapter2()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void Chapter3()
    {
        SceneManager.LoadSceneAsync(8);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void Credits()
    {
        SceneManager.LoadScene(7);
    }
    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
   
}
