using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A class following singleton design pattern to keep track of objectives
/// </summary>
public sealed class Objective
{
    private static Objective instance = null;
    private static Queue<string> objectives = new Queue<string>();

    private Objective()
    {
        objectives.Enqueue("Objective1");
        objectives.Enqueue("Objective2");
        objectives.Enqueue("Objective3");
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
}
