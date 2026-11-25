using System;
using System.IO.Enumeration;
using System.IO;
using System.Security.Cryptography;
class Program
{
    static void Main(string[] args)
    {
        List<Goal> GoalList = new List<Goal>()
        {
                 
        };

        int totalScore = 0;

        // Main application loop managing the navigation menu
        while (true)
        {       
            Console.WriteLine($"Current Score: {totalScore}");
            Console.WriteLine("Welcome to the Activity Menu!");
            Console.WriteLine("1. Create new Goal \n2. List the Goals \n3. Save Goals \n4. Load Goals \n5. Record Goals \n6. Quit \nSelect a choice from the menu:");
            Console.WriteLine("Enter an option 1-6 to continue...");

              // Validate user input safely
            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                Console.WriteLine("Invalid input. Please enter a number 1-6.");
                continue;
            }

            // Polymorphic instantiation and execution based on selection
            if (option == 1)
            {
                Console.WriteLine("The goal types are: \n1. Simple Goal \n2. Eternal Goal \n3. CheckList Goal");
                Console.WriteLine("Which goal would you like to make?");
                
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out int option2))
                    {
                        Console.WriteLine("Invalid input. Please enter a number 1-3.");
                    }
                    else if(option2 == 1)// to simple goal
                    {
                        Console.WriteLine("What is the name of your goal?");
                        string _title = Console.ReadLine();
                        Console.WriteLine("What is a description of the goal?");
                        string _description = Console.ReadLine();
                        Console.WriteLine("How many points do you to assign to the goal?");
                        int _assignedPoints = int.Parse(Console.ReadLine());
                        int _timesCompleted = 0;
                        int _points = 0;
                        bool _complete = false;
                        SimpleGoal newGoal = new SimpleGoal(_title, _description, _assignedPoints, _points, _complete, _timesCompleted);
                        GoalList.Add(newGoal);
                        break;
                    }
                   
                    else if(option2 == 2)// to eternal goal
                    {
                        Console.WriteLine("What is the name of your goal?");
                        string _title = Console.ReadLine();
                        Console.WriteLine("What is a description of the goal?");
                        string _description = Console.ReadLine();
                        Console.WriteLine("How many points do you to assign to the goal?");
                        int _assignedPoints = int.Parse(Console.ReadLine());
                        int _timesCompleted = 0;
                        int _points = 0;
                        bool _complete = false;
                        EternalGoal newGoal = new EternalGoal(_title,  _description, _assignedPoints, _points, _complete, _timesCompleted);
                        GoalList.Add(newGoal);
                        break;
                    }
                    
                    else if(option2 == 3)// to checklist goal
                    {
                        Console.WriteLine("What is the name of your goal?");
                        string _title = Console.ReadLine();
                        Console.WriteLine("What is a description of the goal?");
                        string _description = Console.ReadLine();
                        Console.WriteLine("How many points do you want to assign to the goal?");
                        int _assignedPoints = int.Parse(Console.ReadLine());
                        Console.WriteLine("How many times does this goal need to be performed?");
                        int _timesCompleted = int.Parse(Console.ReadLine());
                        int _points = 0;
                        bool _complete = false;
                        CheckListGoal newGoal = new CheckListGoal(_title, _description, _assignedPoints, _points, _complete, _timesCompleted);
                        GoalList.Add(newGoal);
                        break;
                    }
                    
                    else
                    {
                        Console.WriteLine("Invalid option. Press enter to try again.");
                        Console.ReadLine();
                        break;
                    }
                }
            }

            else if (option == 2) //display the lists that were made by the user
            {
                foreach (Goal goal in GoalList)
                {
                    goal.Display();
                }
            }

            else if (option == 3)
            {
                Console.WriteLine("What would you like to name the file where the goals will be saved? ");
                string filename = Console.ReadLine();
                
                using (StreamWriter outputFile = new StreamWriter(filename)) //streamwriter, saves to the computer and remains there even after program is closed
                {
                    foreach (Goal entry in GoalList) //reads through each entry in the entry list
                    {
                        outputFile.WriteLine(entry.GetSaveString().line);//updates the file with the date, prompt, and entry from the user
                    }
                }
                
                Console.WriteLine("File saved successfully.\n");// notifies the user that the file has been saved.
            }

            else if (option == 4)//load and display files made by streamreader
            {
                Console.WriteLine("Which file would you like to load?"); //prompts user to type a specific file to be loaded
                string filename = Console.ReadLine();
                Console.WriteLine("");//empty line to ease readability in terminal

                if (!File.Exists(filename)) // if the file name cannot be found print "File not found."
                {
                    Console.WriteLine("File not found.");
                    continue;
                }

                foreach (string line in File.ReadAllLines(filename)) //reads the file given by the user and formats the lines in a certain format
                {
                    // Expected format example: "[ ] Title: Description"
                    int closeBracket = line.IndexOf("] ");
                    int colonIndex = line.IndexOf(":", closeBracket + 2);

                    if (closeBracket != -1 && colonIndex != -1) 
                    {
                        string title = line.Substring(closeBracket + 2, colonIndex - (closeBracket + 2)).Trim();
                        bool isComplete = line.StartsWith("[X]");
                        

                        GoalList.Add(new SimpleGoal(title, "", 0, 0, isComplete, 0)); //title,  _description, _assignedPoints, _points, _complete, _timesCompleted
                    }
                }
                Console.WriteLine($"Loaded {GoalList.Count} goal(s) from {filename}:");
                
                using (StreamReader reader = new StreamReader(filename)) //streamReader, shows files that were made by the user
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content);  
                }
            }

            else if (option == 5)// this option records the completion and points of goals
            {
                if (GoalList.Count == 0)
                {
                    Console.WriteLine("No goals available to record. Load or create a goal first."); //if there are no goals made in the menu of files loaded print "No goals available to record. Load or create a goal first."
                    continue;
                }

                Console.WriteLine("The goals are:"); // prepares the list of goals to be displayed in numerical order
                for (int i = 0; i < GoalList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {GoalList[i].GetTitle()}");
                }

                Console.WriteLine("Which goal did you accomplish?");// takes the input of the user and marks that goal as complete
                if (int.TryParse(Console.ReadLine(), out int selection) && selection >= 1 && selection <= GoalList.Count)
                {
                    Goal selectedGoal = GoalList[selection - 1];
                    Console.WriteLine($"You selected: {selectedGoal.GetTitle()}");
                    totalScore += selectedGoal.ScoreGoal();
                    
                    
                }
                else // if invalid input print "invalid goal selection"
                {
                    Console.WriteLine("Invalid goal selection.");
                }

            }           

            else if (option == 6)// quits the program when user inputs 6 from the main menu
            {
                Console.WriteLine("Thank you for participating!\nHave a nice day.");
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
