using System;

// Bonus random selection only uses visible words, so each turn hides new words

class Program
{
    static void Init(Scripture scripture)
    {
        if (scripture is null)
        {
            throw new ArgumentNullException(nameof(scripture));
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
    }

    static void Main()
    {
        Library library = new Library();
        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Init(scripture);

            if (scripture.IsCompletelyHidden())
            {
                return;
            }

            Console.Write("Press enter to continue or type 'quit' to finish ");
            string? input = Console.ReadLine();

            if (input is null || input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}
