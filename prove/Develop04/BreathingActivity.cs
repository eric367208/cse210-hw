using System;
using System.Threading;

namespace Activity
{
    // Inheritance: BreathingActivity inherits all base behaviors and attributes from Activity
    public class BreathingActivity : Activity
    {
        public void Run()
        {
            // Execute the standard setup and starting preparation
            RunStartingMessage();

            int duration = int.Parse(_activityDuration);
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);

            // Loop alternating between deep breathing in and out until the duration runs out
            while (DateTime.Now < endTime)
            {
                Console.Write("\nBreathe in...");
                CountDown(4);
                Console.WriteLine();

                if (DateTime.Now >= endTime) break;

                Console.Write("Now breathe out...");
                CountDown(6);
                Console.WriteLine();
            }

            // Execute the standard wrap-up and ending message
            RunEndingMessage();
        }
    }
}
