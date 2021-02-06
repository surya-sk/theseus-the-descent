using UnityEngine;

public class SavingDemo: MonoBehaviour
{
    SceneLoader sceneLoader;
    string saveFile;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        saveFile = sceneLoader.GetSceneName();
        Load();        
    }
    public void Save()
    {
        GetComponent<SavingSystem>().Save(saveFile);
    }

    public void SaveAndQuit()
    {
        Save();
        sceneLoader.MainMenu();
    }

    public void Load()
    {
        GetComponent<SavingSystem>().Load(saveFile);
    }
}