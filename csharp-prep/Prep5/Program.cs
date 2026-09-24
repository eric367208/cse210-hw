using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        int year;
        PromptUserBirthYear(out year);

        string Name = PromptUserName();

        int UserNumber = PromptUserNumber();
    
    
        int squarednumber = SquareNumber(UserNumber);
        DisplayResult(squarednumber, year, Name);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program. ");
    }

    static string PromptUserName()
    {
        Console.WriteLine("What is your name");
        string Name = Console.ReadLine();
        return Name;
    }

    static void PromptUserBirthYear(out int year)
    {
        Console.WriteLine("What was the year you were born? "); 
        year = int.Parse(Console.ReadLine());
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("What is your favorite number? ");
        int FavNum = int.Parse(Console.ReadLine());
        return FavNum;
    }

    static int SquareNumber(int num)

    {
        int square = num*num;
        return square;
    }

    static void DisplayResult(int square, int year, string Name)
    {
        Console.WriteLine($"{Name}, the square of your number is {square}.");
        Console.WriteLine($"{Name}, you will turn {2026 - year} years old this year.");
    }
}




