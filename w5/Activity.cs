class Activity
{
    private readonly string _name;
    private readonly string _description;
    private readonly int _duration;

    public Activity(
        string name,
        string description,
        int duration
    )
    {
        Guard.NotNullOrWhiteSpace(name, nameof(name), "Name cannot be empty");
        Guard.NotNullOrWhiteSpace(description, nameof(description), "description cannot be empty");
        Guard.Positive(duration, nameof(duration), "duration must be greater than zero");

        _name = name.Trim();
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Start activity {_name} - {_description} : duration {_duration}");
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Great job! Duration - {_duration}");
    }

    public void ShowSpinner(int seconds)
    {
        Guard.Positive(seconds, nameof(seconds), "seconds must be greater than zero");

        string[] spinner = { "|", "/", "-", "\\" };

        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }

    public void ShowCountDown(int seconds)
    {
        Guard.Positive(seconds, nameof(seconds), "seconds must be greater than zero");

        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public int GetDuration()
    {
        return _duration;
    }
}
