//Provide for simple goals that can be marked complete and the user gains some value.
//For example, if you run a marathon you get 1000 points.
class SimpleGoal : Goal
{
    //protected bool _complete;
    
    public SimpleGoal(string _title, string _description, int _assignedPoints, int _points, bool _complete, int _timesCompleted) : base(_title, _description, _assignedPoints, _points, _complete, _timesCompleted)
    {
        
    }
    
    public override void Display()
    {
        string status = _complete ? "X" : " ";
        Console.WriteLine($"[{status}] {_title}: {_description}");
        Console.WriteLine($"    This goal has {_assignedPoints} points assigned to it");
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
    public override string GetTitle()
    {
        return _title;
    }
}
