Random randomGenerator = new Random(); //Generates a random number.

int Number = randomGenerator.Next(1,100); //Sets range of random number and sets it as an int.

int guess = 0; //initializes the guess

Console.WriteLine("Guess the magic number. "); //Prompts the user to guess the number.

while (guess != Number) //Sets a loop until the correct number is guessed.
{

    guess = int.Parse(Console.ReadLine()); //Converts the guess to an int.

    if (guess < Number) //If statement to give direction to the user to make a better guess.
    {
        Console.Write("Higher, guess again. ");
    }
    else if (guess > Number)
    {
        Console.Write("Lower, guess again. ");
    }
}

Console.WriteLine("You guessed the magic number! "); //congratulates the user upon a successful guess.
