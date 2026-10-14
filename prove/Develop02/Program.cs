using System;
using System.Net;
using System.Runtime.InteropServices;

// Exceeds requirements: Implemented a search feature (Option 5) allowing users 
// to filter saved journal entries by keyword across text, dates, and prompts.
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        string response = "";
        
        while (response != "0" )
        {
            Console.WriteLine("Type a number 0-5 to navigate the menu.\n");
            Console.WriteLine("1. Write a new entry. ");
            Console.WriteLine("2. Display the journal. ");
            Console.WriteLine("3. Save the journal to a file. ");
            Console.WriteLine("4. Load the journal from a file. ");
            Console.WriteLine("5. Search journal entries. ");
            Console.WriteLine("0. Quit.\n");

            response = Console.ReadLine();
            Console.WriteLine();


            if (response == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"{prompt}\n");
                string userEntry = Console.ReadLine();

                string longDate = DateTime.Now.ToLongDateString();

                Entry newEntry = new Entry(longDate, prompt, userEntry);
                //newEntry._date = longDate;
                //newEntry._promptText = prompt;
                //newEntry._entryText = userEntry;

                journal.AddEntry(newEntry);
                Console.WriteLine();
            }

            else if (response == "2")
            {
                journal.DisplayJournal();
            }

            else if (response =="3")
            {
                Console.WriteLine("What is the filename?\n");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (response == "4")
            {
                Console.WriteLine("What is the filename that you would like to load?");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }

            else if (response == "5") // New option handler
            {
                Console.WriteLine("What word or phrase would you like to search for?");
                string searchTerm = Console.ReadLine();
                journal.SearchEntries(searchTerm);
            }
            
            else if (response == "0")
            {
                Console.WriteLine("Thank you and have a nice day. ");
            }

            else
            {
                Console.WriteLine("That choice is invalid.\n");
            }
        }

    }
}
