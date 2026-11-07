using System;
using System.Collections.Generic;
using System.Threading;

namespace Activity
{
    // Inheritance: ListingActivity inherits from the Activity base class
    public class ListingActivity : Activity
    {
        // Encapsulation: Private list holding prompt choices specific to listing
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public void Run()
        {
            RunStartingMessage();

            Console.Clear();
            Console.WriteLine("List as many responses you can to the following prompt:");
            
            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];
            Console.WriteLine($" --- {prompt} ---\n");
            
            Console.Write("You may begin in: ");
            CountDown(5);
            Console.WriteLine();

            List<string> userItems = new List<string>();
            int duration = int.Parse(_activityDuration);
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);

            // Continuously accept user input items until the duration limit is reached
            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                if (Console.KeyAvailable)
                {
                    string item = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        userItems.Add(item);
                    }
                }
                else
                {
                    Thread.Sleep(200); 
                    if (DateTime.Now >= endTime) break;
                }
            }

            Console.WriteLine($"\nYou listed {userItems.Count} items!");
            RunEndingMessage();
        }
    }
}
