using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A class following singleton design pattern to keep track of objectives
/// </summary>
public sealed class Objective
{
    private static Objective instance = null;
    private static Queue<string> objectives = new Queue<string>();
    private string objectiveString = "";
    private string initialObjectiveList = "Objective1 Objective2 Objective3";
    string path = Application.persistentDataPath + "/objectives.txt";

    private Objective()
    {
        ReadObjectives();
        foreach (string objective in objectiveString.Split(' '))
        {
            objectives.Enqueue(objective);
        }
    }

    /// <summary>
    /// Returns the current instance
    /// </summary>
    public static Objective Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new Objective();
            }
            return instance;
        }
    }

    public string GetCurrentObjective()
    {
        return objectives.Peek();
    }

    public void FinishObjective()
    {
        objectives.Dequeue();
    }

    private void ReadObjectives()
    {
         if(!File.Exists(path))
        {
            WriteObjective(initialObjectiveList);
        }
        using(StreamReader streamReader = new StreamReader(path))
        {
            objectiveString = streamReader.ReadLine();
        }
        Debug.Log(objectiveString);
    }

    private void WriteObjective(string objective)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);
        StreamWriter streamWriter = new StreamWriter(fileStream);
        streamWriter.Write(objective);
        Debug.Log("Writing to file : " + objective);
        streamWriter.Close();
    }
}
