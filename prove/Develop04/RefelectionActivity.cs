using System;
using System.Collections.Generic;
using System.Threading;

namespace Activity
{
    // Inheritance: ReflectionActivity inherits from the Activity base class
    public class ReflectionActivity : Activity
    {
        // Encapsulation: Private lists containing prompt and question data internal to this class
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public void Run()
        {
            RunStartingMessage();

            Console.Clear();
            Console.WriteLine("Consider the following prompt:\n");
            
            // Select and display a random prompt
            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];
            Console.WriteLine($" --- {prompt} ---\n");
            
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();

            Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
            Console.Write("You may begin in: ");
            CountDown(5);
            Console.Clear();

            int duration = int.Parse(_activityDuration);
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);

            // Display sequential random questions separated by spinner animations until time expires
            while (DateTime.Now < endTime)
            {
                string question = _questions[rand.Next(_questions.Count)];
                Console.Write($"> {question} ");
                Spinner(5);
                Console.WriteLine();
            }

            RunEndingMessage();
        }
    }
}
