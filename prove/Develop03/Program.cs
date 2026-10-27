using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Initialize your reference and scripture text
        
        Reference reference = new Reference("D&C", 121, 45);
        string text = "Let thy bowels also be full of charity towards all men, and to the household of faith, and let virtue garnish thy thoughts unceasingly; then shall thy confidence wax strong in the presence of God; and the doctrine of the priesthood shall distil upon thy soul as the dews from heaven.";
        
        Scriptures scripture = new Scriptures(reference, text);
        
        string userInput = "";
        Random random = new Random();

        // Main loop 
        while (userInput != "quit")
        {
            Console.Clear();
            
            // Display the reference and the scripture (with hidden words if any)
            Console.WriteLine(scripture.DisplayText());

            // Check if all words are hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden! Great job memorizing!");
                break;
            }

            // Prompt user
            Console.WriteLine("\nPress enter to continue or type 'quit' to exit.");
            userInput = Console.ReadLine();

            // If user pressed Enter (and didn't type quit), hide random words
            if (userInput == "")
            {
                scripture.HideWords(random, 3); // Hides 3 random words per enter press
            }
        }
    }
}
