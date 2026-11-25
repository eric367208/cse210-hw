using System.ComponentModel.DataAnnotations;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

public abstract class Goal 
{
    protected string _title;
    protected string _description;
    protected int _points;
    protected bool _complete;
    protected int _assignedPoints;
    protected int _timesCompleted;
    protected Goal(string title, string description, int assignedPoints, int points, bool complete, int timesCompleted)
    {
        _title = title;
        _description = description;
        _assignedPoints = assignedPoints;
        _points = points;
        _complete = complete;
        _timesCompleted = timesCompleted;
    }
    public abstract void Display();
    public abstract (string line, int assignedPoints) GetSaveString();
    public abstract int ScoreGoal();
    public abstract string GetTitle();

}
