class ReflectingActivity : Activity
{
    public ReflectingActivity()
        : this(30)
    {
    }

    public ReflectingActivity(int duration)
        : base(
            "Reflecting Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
            duration)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine();
        DisplayPrompt();
        Console.WriteLine("When you have something, press enter to continue");
        Console.ReadLine();
        Console.WriteLine("Now ponder each of the following questions as they relate to this experie");
        Console.Write("You may begin in: ");
        ShowCountDown(3);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            DisplayQuestion();
            int remainingSeconds = Math.Max(1, (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds));
            ShowSpinner(Math.Min(5, remainingSeconds));
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        return ActivityPrompts.Reflecting[Random.Shared.Next(ActivityPrompts.Reflecting.Count)];
    }

    public string GetRandomQuestion()
    {
        return ActivityPrompts.ReflectionQuestions[Random.Shared.Next(ActivityPrompts.ReflectionQuestions.Count)];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($"{GetRandomPrompt()}");
    }

    public void DisplayQuestion()
    {
        Console.WriteLine($"> {GetRandomQuestion()}");
    }
}
