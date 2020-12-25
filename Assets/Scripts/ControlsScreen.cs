///<summary>
/// A helper script to inefficiently navigate back to the main menu from
/// the controls page
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsScreen : MonoBehaviour
{
    [SerializeField] Canvas MainMenu;
    [SerializeField] Canvas ControlsMenu;
    [SerializeField] Button BackButton;

    // Update is called once per frame
    void Update()
    {
        if(ControlsMenu.isActiveAndEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                GoBack();
            }
        }
    }

    /// <summary>
    /// Navigate to the main menu
    /// </summary>
    void GoBack()
    {
        SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
        sceneLoader.MainMenu();
    }
}
