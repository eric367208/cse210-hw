
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

List <int> numbers = new List<int>(); //Creating a list
int num = -1; // initializing the variable


// prompting the user to enter numbers and exit when done
Console.WriteLine("To stop entering numbers into the list enter 0.");
Console.Write("Enter a number into the list. ");

while ( num != 0) // While loop to make a list with prompting the user only once
{
    num = int.Parse(Console.ReadLine()); // This prohibits the loop from repeating endlessly
    Console.Write("Enter a number ");
    if (num != 0) // Keeps 0 from being added to the list
    {
        numbers.Add(num);
    }
}

int sum = numbers.Sum(); // initializes the variable sum

Console.WriteLine($"The sum of the list is {sum}"); // prints the sum of the list

double count = numbers.Count; // initializes the variable count

double avg = sum/count; // initializes the variable avg
                        // Divides the sum and count and preserves the decimal.
                        // Making sum an int and count a double allows the decimal
                        // to be kept.

Console.WriteLine($"The average of the list is {avg}"); // Prints the average

int max = numbers[0]; //initializes the variable max from the library
int min = numbers[0]; //initializes the variable min from the library

foreach (int number in numbers) // Foreach iterates through the list
{
    if (number > max) // finds the maximum
    {
        max = number; // gives max the value of number
    }

    if (number < min) // finds the minimum
    {
        min = number; //gives min the value of number
    }
}
Console.WriteLine($"The maximimum in the list is: {max}"); // Prints the maximum
Console.WriteLine($"The minimum in the list is: {min}"); //// Prints the minimum
