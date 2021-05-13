///<summary>
///Handles transition between scenes
///</summary>
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public TextMeshProUGUI loadingText;
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

    public void RestartGame()
    {
        Directory.Delete(Application.persistentDataPath, true);
        StartGame();
    }

    public void Tutorial()
    {
        LoadScene(1);
    }

    public void Chapter1()
    {
        LoadScene(2);
    }

    private void LoadScene(int index)
    {
        StartCoroutine(LoadAsync(index));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        if (operation.progress < 1.0) 
        {
            loadingText.text = "Loading...";
            yield return new WaitForSeconds(3);
        }
        loadingText.text = string.Empty;
    }

    public void Chapter2()
    {
        LoadScene(3);
    }

    public void Chapter3()
    {
        LoadScene(8);
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
