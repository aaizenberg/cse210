using System;

class Program
{
    static void Main()
    {
        ShowWelcome();

        string name = ReadName();
        int favoriteNumber = ReadNumber("Enter your favorite number ");

        int squaredNumber = Square(favoriteNumber);

        ShowResult(name, squaredNumber);
    }

    static void ShowWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string ReadName()
    {
        while (true)
        {
            Console.Write("Enter your name ");

            string name = Console.ReadLine()?.Trim() ?? "";

            if (!string.IsNullOrWhiteSpace(name))
            {
                return name;
            }

            Console.WriteLine("Name cannot be empty");
        }
    }

    static int ReadNumber(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                return number;
            }

            Console.WriteLine("Please enter a valid numbe");
        }
    }

    static int Square(int number)
    {
        return number * number;
    }

    static void ShowResult(string name, int square)
    {
        Console.WriteLine($"{name},the square of your number is {square}");
    }
}

