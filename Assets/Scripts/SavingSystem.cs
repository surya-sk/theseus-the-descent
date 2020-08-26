using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SavingSystem : MonoBehaviour
{
    public void Save(string saveFile)
    {
        Dictionary<string, object> state = LoadFile(saveFile);
        CaptureState(state);
        SaveFile(saveFile, state);
    }


    public void Load(string saveFile)
    {
        RestoreState(LoadFile(saveFile));
    }

    private void SaveFile(string saveFile, object state)
    {
        string path = GetSavePath(saveFile);
        print("Saving to " + path);
        using(FileStream fileStream = File.Open(path, FileMode.Create))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, state);
        }
        
    }

    private Dictionary<string, object> LoadFile(string saveFile)
    {
        string path = GetSavePath(saveFile);
        print("Loading from " + path);
        if(!File.Exists(path))
        {
            return new Dictionary<string, object>();
        }
        using (FileStream fileStream = File.Open(path, FileMode.Open))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return (Dictionary<string, object>)binaryFormatter.Deserialize(fileStream);
        }
    }

    private void CaptureState(Dictionary<string, object> state)
    {
        foreach(SaveableObject saveable in FindObjectsOfType<SaveableObject>())
        {
            state[saveable.GetUniqueIdentifier()] = saveable.CaptureState();
        }     
    }


    private void RestoreState(Dictionary<string, object> state)
    {
        foreach (SaveableObject saveable in FindObjectsOfType<SaveableObject>())
        {
            string id = saveable.GetUniqueIdentifier();
            if(state.ContainsKey(id))
            {
                saveable.RestoreState(state[id]);
            }
              
        }
    }




    private string GetSavePath(string saveFile)
    {
        return Path.Combine(Application.persistentDataPath, saveFile + ".sav");
    }


}
