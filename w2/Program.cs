using System;

class Program
{

    static void ShowMenu()
    {
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Save");
        Console.WriteLine("4. Load");
        Console.WriteLine("5. Quit");
    }

    static void Main()
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal journal = new Journal();

        bool running = true;

        while (running)
        {
            ShowMenu();
            Console.Write("Select a choice from the menu: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();

                    Console.WriteLine(prompt);
                    string response = Console.ReadLine() ?? string.Empty;

                    string date = DateTime.Now.ToShortDateString();
                    Entry entry = new Entry(date, prompt, response);

                    journal.AddEntry(entry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Filename: ");
                    string? saveFile = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(saveFile))
                    {
                        journal.SaveToFile(saveFile);
                    }
                    break;

                case "4":
                    Console.Write("Filename: ");
                    string? loadFile = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(loadFile))
                    {
                        journal.LoadFromFile(loadFile);
                    }
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
