using System;
using System.Collections.Generic;
using System.Threading;

namespace Activity
{
    public class Activity
    {
        // Encapsulation: Protected fields hide internal state from outside code 
        // while allowing derived activity classes to access them directly.
        protected string _activityName = "";
        protected string _activityDescription = "";
        protected string _activityDuration = "";

        // Exceeding Requirements: A static dictionary shared across all activity instances 
        // to securely keep track of how many times each activity was performed during the session.
        private static Dictionary<string, int> _activityLog = new Dictionary<string, int>()
        {
            { "Listing Activity", 0 },
            { "Reflection Activity", 0 },
            { "Breathing Activity", 0 }
        };

        // Encapsulation: Getters and setters control access to private/protected properties.
        public string GetActivityName() => _activityName;
        public void SetActivityName(string activityName) => _activityName = activityName;

        public string GetActivityDescription() => _activityDescription;
        public void SetActivityDescription(string activityDescription) => _activityDescription = activityDescription;

        public string GetActivityDuration() => _activityDuration;
        public void SetActivityDuration(string activityDuration) => _activityDuration = activityDuration;

        // Increments the count for the current activity in the session log
        public void RecordActivityCompletion()
        {
            if (_activityLog.ContainsKey(_activityName))
            {
                _activityLog[_activityName]++;
            }
        }

        // Displays the performance log tracking how many times each activity was completed
        public static void DisplayActivityLog()
        {
            Console.Clear();
            Console.WriteLine("=== Activity Performance Log ===");
            foreach (KeyValuePair<string, int> entry in _activityLog)
            {
                Console.WriteLine($"- {entry.Key}: Completed {entry.Value} time(s)");
            }
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }

        // Displays a spinner animation for a designated number of seconds
        public void Spinner(int seconds)
        {
            List<string> animation = new List<string> { "|", "/", "-", "\\" };
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(seconds);
            int i = 0;

            while (DateTime.Now < endTime)
            {
                Console.Write(animation[i]);
                Thread.Sleep(250);
                Console.Write("\b");
                i = (i + 1) % animation.Count;
            }
            Console.Write(" \b"); // Clear final spinner character
        }

        // Displays a numerical countdown timer (e.g., 5, 4, 3...)
        public void CountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        // Standard starting message shared by all activities
        public void RunStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_activityName}.\n");
            Console.WriteLine($"{_activityDescription}\n");
            Console.Write("For the activity you selected, how long would you like the duration of the activity to be (in seconds)? ");
            _activityDuration = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Get ready...");
            Spinner(3);
        }

        // Standard ending message shared by all activities
        public void RunEndingMessage()
        {
            // Automatically log completion when an activity finishes successfully
            RecordActivityCompletion();

            Console.WriteLine("\nWell done!!");
            Spinner(3);
            Console.WriteLine($"\nYou have completed another {_activityDuration} seconds of the {_activityName}.");
            Spinner(3);
        }
    }
}
