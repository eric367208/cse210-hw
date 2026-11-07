using System;
using Activity;

class Program
{
    static void Main(string[] args)
    {
        // Main application loop managing the navigation menu
        while (true)
        {       
            Console.Clear();
            Console.WriteLine("Welcome to the Activity Menu!");
            Console.WriteLine("Menu Options:\n 1. Listing Activity \n 2. Reflection Activity \n 3. Breathing Activity \n 4. View Activity Log \n 5. Quit");
            Console.WriteLine("Enter an option 1-5 to continue...");
            
            // Validate user input safely
            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                Console.WriteLine("Invalid input. Please enter a number 1-5.");
                Thread.Sleep(1500);
                continue;
            }

            // Polymorphic instantiation and execution based on selection
            if (option == 1)
            {
                ListingActivity list1 = new ListingActivity();
                list1.SetActivityName("Listing Activity");
                list1.SetActivityDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                list1.Run();
            }
            else if (option == 2)
            {
                ReflectionActivity reflection1 = new ReflectionActivity();
                reflection1.SetActivityName("Reflection Activity");
                reflection1.SetActivityDescription("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                reflection1.Run();
            }
            else if (option == 3)
            {
                BreathingActivity breathing1 = new BreathingActivity();
                breathing1.SetActivityName("Breathing Activity");
                breathing1.SetActivityDescription("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
                breathing1.Run();
            }
            else if (option == 4)
            {
                // Accesses the static performance log method from the base class
                Activity.Activity.DisplayActivityLog();
            }
            else if (option == 5)
            {
                Console.WriteLine("Thank you for participating!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Press enter to try again.");
                Console.ReadLine();
            }
        }
    }
}
