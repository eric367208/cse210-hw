using System.ComponentModel.DataAnnotations;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;

//Provide for a checklist goal that must be accomplished a certain number of times to be complete. Each time the user records this goal they gain some value,
//but when they achieve the desired amount, they get an extra bonus.
//For example, if you set a goal to attend the temple 10 times, you might get 50 points each time you go, and then a bonus of 500 points on the 10th time.

public class CheckListGoal : Goal 
{
    public CheckListGoal(string _title, string _description, int _assignedPoints, int _points, bool _complete, int _timesCompleted) : base(_title, _description, _assignedPoints, _points, _complete, _timesCompleted)
    {
        
    }
        protected int _bonusScore;
        protected int _bonusThreshold;
        //protected int _performed; is this the same as _completed?


    public override void Display()
    {
        string status = _complete ? "X" : " ";
        Console.WriteLine($"[{status}] {_title} \n{_description}.----Currently completed /{_bonusScore}");
        //Console.WriteLine($"    This goal has {_assignedPoints} points");
    }
    public override (string line, int assignedPoints) GetSaveString()
    {
        string status = _complete ? "X" : " ";
        string line = $"[{status}] {_title}: {_description}\n   "; //This goal has {_assignedPoints} points assigned to it
        int assignedPoints = _assignedPoints;
        return (line, assignedPoints);

    }
    public override int ScoreGoal()
    {
        _complete = true;
        GetSaveString();
        
        
        return _assignedPoints;
    }
    //public override void Award();

    public override string GetTitle()
    {
        return _title;
    }

}
