class SessionHistory
{
    private readonly List<ActivitySession> _sessions = new List<ActivitySession>();

    public void Add(string activityName, int duration, string result)
    {
        _sessions.Add(new ActivitySession(activityName, duration, result));
    }

    public void Display()
    {
        if (_sessions.Count == 0)
        {
            Console.WriteLine("No data");
            return;
        }

        Console.WriteLine("Session history");
        foreach (ActivitySession session in _sessions)
        {
            Console.WriteLine(session);
        }
    }
}

class ActivitySession
{
    private readonly string _activityName;
    private readonly int _duration;
    private readonly string _result;
    private readonly DateTime _completedAt;

    public ActivitySession(string activityName, int duration, string result)
    {
        Guard.NotNullOrWhiteSpace(activityName, nameof(activityName), "activity name cannot be empty");
        Guard.Positive(duration, nameof(duration), "duration must be greater than zero");
        Guard.NotNullOrWhiteSpace(result, nameof(result), "result cannot be empty");

        _activityName = activityName;
        _duration = duration;
        _result = result;
        _completedAt = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{_completedAt:HH:mm} {_activityName} {_duration} seconds - {_result}";
    }
}
