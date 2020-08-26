using UnityEngine;

public class SavingDemo: MonoBehaviour
{
    const string saveFile = "save";

    private void Start()
    {
        Load();        
    }
    public void Save()
    {
        GetComponent<SavingSystem>().Save(saveFile);
    }

    public void SaveAndQuit()
    {
        Save();
        FindObjectOfType<SceneLoader>().MainMenu();
    }

    public void Load()
    {
        GetComponent<SavingSystem>().Load(saveFile);
    }
}