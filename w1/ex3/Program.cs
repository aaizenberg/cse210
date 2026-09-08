using System;

class Program
{
    static void Main(String[] argc)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        while (guess != magicNumber)
        {
            int num = getNum();

            string result = magicNumber.CompareTo(num) switch
            {
                > 0 => "Higher",
                < 0 => "Lower",
                _ => "You guessed it!"
            };

            Console.WriteLine(result);
        }
    }

    static int getNum()
    {
        while (true)
        {
            Console.Write("What is your guess? ");

            if (int.TryParse(Console.ReadLine(), out int num))
            {
                return num;
            }

            Console.Write("Please enter a valid number");
        }
    }
}