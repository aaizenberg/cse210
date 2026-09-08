using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = [];

        while (true)
        {
            Console.Write("Enter a number 0 to quit ");

            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Please enter a valid number ");
                continue;
            }

            if (number == 0)
            {
                break;
            }

            numbers.Add(number);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers entered");
            return;
        }

        Console.WriteLine($"The sum is {numbers.Sum()}");
        Console.WriteLine($"The average is {numbers.Average()}");
        Console.WriteLine($"The max is {numbers.Max()}");
    }
}