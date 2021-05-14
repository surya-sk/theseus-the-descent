using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Ends chapter 1
/// </summary>
public class EndChapter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "Chapter 1":
                SceneManager.LoadScene(5);
                break;
            case "Chapter 2":
                SceneManager.LoadScene(6);
                break;
            case "The End":
                SceneManager.LoadScene(7);
                break;
        }
    }
}
