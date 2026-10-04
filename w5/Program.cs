// Creativity feature users can view a history of mindfulness activities

class Program
{
    private static readonly SessionHistory _sessionHistory = new SessionHistory();

    static void Main()
    {
        bool isRunning = true;

        while (isRunning)
        {
            ShowMenu();
            Console.Write("Select an option ");
            string? choice = Console.ReadLine();

            if (choice is null)
            {
                break;
            }

            switch (choice)
            {
                case "1":
                    StartBreathingActivity();
                    break;
                case "2":
                    StartReflectionActivity();
                    break;
                case "3":
                    StartListingActivity();
                    break;
                case "4":
                    _sessionHistory.Display();
                    break;
                case "5":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Welcome!");
        Console.WriteLine("1. Start breathing activity");
        Console.WriteLine("2. Start reflection activity");
        Console.WriteLine("3. Start listing activity");
        Console.WriteLine("4. View session history");
        Console.WriteLine("5. Quit");
    }

    static void StartBreathingActivity()
    {
        int duration = GetDuration();
        BreathingActivity breathingActivity = new BreathingActivity(duration);
        breathingActivity.Run();
        _sessionHistory.Add("Breathing Activity", duration, "Completed");
    }

    static void StartReflectionActivity()
    {
        int duration = GetDuration();
        ReflectingActivity reflectingActivity = new ReflectingActivity(duration);
        reflectingActivity.Run();
        _sessionHistory.Add("Reflecting Activity", duration, "Completed");
    }

    static void StartListingActivity()
    {
        int duration = GetDuration();
        ListingActivity listingActivity = new ListingActivity(duration);
        listingActivity.Run();
        _sessionHistory.Add("Listing Activity", duration, $"Listed {listingActivity.GetCount()} item(s)");
    }

    static int GetDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds? ");

            if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
            {
                return duration;
            }

            Console.WriteLine("Please enter a whole number > 0");
        }
    }
}
