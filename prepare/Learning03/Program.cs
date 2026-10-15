using System;

class Program
{
    static void Main(string[] args)
    {
        // Step 4 & 5: Verify constructors, setters, and getters
        Fraction f1 = new Fraction(); // 1/1
        Fraction f2 = new Fraction(6); // 6/1
        Fraction f3 = new Fraction(6, 7); // 6/7

        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f3.GetFractionString());

        // Step 6: Test sample fraction representations
        Fraction test1 = new Fraction(1);
        Fraction test2 = new Fraction(5);
        Fraction test3 = new Fraction(3, 4);
        Fraction test4 = new Fraction(1, 3);

        Fraction[] samples = { test1, test2, test3, test4 };
        foreach (var f in samples)
        {
            Console.WriteLine(f.GetFractionString());
            Console.WriteLine(f.GetDecimalValue());
        }

        Console.WriteLine();
        Console.WriteLine("--- Random Fraction Loop (20 iterations) ---");

        // Step 7: Practice using Fraction class with a random loop
        Fraction randomFraction = new Fraction();
        Random random = new Random();

        for (int i = 1; i <= 20; i++)
        {
            int randomTop = random.Next(1, 100);
            int randomBottom = random.Next(1, 100);

            randomFraction.SetTop(randomTop);
            randomFraction.SetBottom(randomBottom);

            Console.WriteLine($"Fraction {i}: string: {randomFraction.GetFractionString()} Number: {randomFraction.GetDecimalValue()}");
        }
    }
}
