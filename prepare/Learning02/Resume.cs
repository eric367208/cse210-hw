using System.Collections.Generic;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name is: {_name} ");
        Console.WriteLine("Jobs: ");

        foreach(Job Job in _jobs)
        {
            Job.Display();
        }
    }
}
