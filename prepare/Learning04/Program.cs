using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Math math1 = new Math();
            math1.SetSection("6.5");
            math1.SetProblems("1-10");
            math1.SetName("James");
            math1.SetTopic("Algebra");
            Console.WriteLine(math1.GetHomeWorkList());

            Writing writing1 = new Writing();
            writing1.SetTitle("Great Wall Of Mirrors");
            writing1.SetName("Codwell");
            writing1.SetTopic("English");
            Console.WriteLine(writing1.GetWritingInfo());
            
            
        }
    }
}
