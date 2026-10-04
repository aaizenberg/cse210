class BreathingActivity : Activity
{
    public BreathingActivity(int duration)
        : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowlyClear your mind and focus on your breathing.",
        duration)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int elapsedTime = 0;

        while (elapsedTime < GetDuration())
        {
            int breathingTime = Math.Min(4, GetDuration() - elapsedTime);
            Console.Write("Breathe in... ");
            ShowCountDown(breathingTime);
            Console.WriteLine();
            elapsedTime += breathingTime;

            if (elapsedTime >= GetDuration())
            {
                break;
            }

            breathingTime = Math.Min(4, GetDuration() - elapsedTime);
            Console.Write("Breathe out... ");
            ShowCountDown(breathingTime);
            Console.WriteLine();
            elapsedTime += breathingTime;
        }

        DisplayEndingMessage();
    }
}
