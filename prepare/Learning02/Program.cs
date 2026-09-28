using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Electrical Engineer";
        job2._company = "Gulfstream";
        job2._startYear = 2008;
        job2._endYear = 2026;

        Resume MyResume = new Resume();
        MyResume._name = "Eric Ames";
        MyResume._jobs.Add(job1);
        MyResume._jobs.Add(job2);

        MyResume.Display();
    }
}
