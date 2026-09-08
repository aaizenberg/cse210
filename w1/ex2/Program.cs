using System;

class Program
{
    static void Main(String[] argc)
    {
        int percent = getPercentage();

        string letter = percent switch
        {
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            _ => "F"
        };

        Console.Write($"Your grade is {letter}");
        Console.Write(percent >= 70 ? " You passed!" : " Better luck next time!");
    }

    static int getPercentage()
    {
        while (true)
        {
            Console.Write("What is your grade percentage? ");

            if (int.TryParse(Console.ReadLine(), out int percent))
            {
                return percent;
            }

            Console.Write("Please enter a valid number");
        }
    }
}