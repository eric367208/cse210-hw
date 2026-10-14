using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = []; //=new List<Entry>(); //making a new list
    public void AddEntry(Entry newEntry) //adding a method to add to the list
    {
        _entries.Add(newEntry); //adds entry to list 
    }

    public void DisplayJournal() //display for digital journal
    {
        if (_entries.Count == 0) // if the number of entries is 0...
        {
            Console.WriteLine("Your journal is currently empty.\n"); //tell the user that the journal is empty
            return;
        }

        foreach (Entry entry in _entries) // for each entry is the list...
        {
            entry.Display(); // display
            Console.WriteLine("-------------------------------------------------------------------"); //seperates each entry by these marks
        }

    }

    public void SaveToFile(string filename) //save entries to entry list
    {
        Console.WriteLine($"Saving to file..."); //prompts the user that the file is being saved

        //filename = ("Entries.txt");
        using (StreamWriter outputFile = new StreamWriter(filename)) //streamwriter, saves to the computer and remains there even after program is closed
        {
            foreach (Entry entry in _entries) //reads through each entry in the entry list
            {
                outputFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}");//updates the file with the date, prompt, and entry from the user
            }
        }

        Console.WriteLine("Journal saved successfully.\n");// notifies the user that the file has been saved.

    }

    public void LoadFromFile(string filename) // load file method
    {
        if (!File.Exists(filename))// if statement to read through file list
        {
            Console.WriteLine("File not found.\n");// notifies the reader of a file not found
            return;
        }

        _entries.Clear(); //loading a current file will overwrite the current session preventing a duplicate of or appending existing entries

        string[] lines = File.ReadAllLines(filename);//creates an array of lines for the files

        foreach (string line in lines) // reades through the array of lines
        {
            string[] parts = line.Split("~|~"); // creates an array of parts from the lines

            if (parts.Length == 3)
            {
                Entry entry = new Entry(parts[0], parts[1], parts[2]); // creates new entry
                entry._date = parts[0]; // entry date
                entry._promptText = parts[1]; // entry prompt
                entry._entryText = parts[2]; // entry text

                _entries.Add(entry); // adds these lines to the entry
            }
        }

        Console.WriteLine("Journal loaded successfully.\n"); // notifies the user that the journal has been loaded
    }


// Search entries by keyword
    public void SearchEntries(string keyword)
    {
        bool found = false;
        Console.WriteLine($"\nSearching for entries containing: '{keyword}'");
        Console.WriteLine("---------------------------------");

        foreach (Entry entry in _entries)
        {
            // Check if the keyword exists in the entry text, date, or prompt (case-insensitive)
            if (entry._entryText.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                entry._date.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                entry._promptText.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                entry.Display();
                Console.WriteLine("---------------------------------");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No matching journal entries found.\n");
        }
    }
}
