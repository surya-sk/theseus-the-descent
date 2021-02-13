/// <summary>
/// A singleton to keep track of the current objective. This class is only for saving objectives
/// </summary>
public sealed class ObjectiveManager
{
    private static ObjectiveManager instance = new ObjectiveManager();
    private string currentObjective;

    private ObjectiveManager()
    {

    }

    public static ObjectiveManager GetInstance()
    {
        return instance;
    }

    public void SetCurrentObjective(string objective)
    {
        currentObjective = objective;
    }

    public string GetCurrentObjective()
    {
        if(currentObjective == null)
        {
            currentObjective = "Go to the office";
        }
        return currentObjective;
    }
}
