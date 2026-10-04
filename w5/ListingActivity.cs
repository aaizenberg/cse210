class ListingActivity : Activity
{
    private int _count;

    public ListingActivity()
        : this(30)
    {
    }

    public ListingActivity(int duration)
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area",
            duration)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine();
        GetRandomPrompt();
        Console.Write("You may begin in ");
        ShowCountDown(3);
        Console.WriteLine();

        List<string> responses = GetListFromUser();
        Console.WriteLine($"listed {_count} items");
        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        Console.WriteLine($"{ActivityPrompts.Listing[Random.Shared.Next(ActivityPrompts.Listing.Count)]}");
    }

    public List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string? response = Console.ReadLine();

            if (response is null)
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(response))
            {
                responses.Add(response.Trim());
                _count++;
            }
        }

        return responses;
    }

    public int GetCount()
    {
        return _count;
    }
}
