public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        ArgumentGuard.NotNullOrWhiteSpace(name, nameof(name), "name required");
        ArgumentGuard.NotNullOrWhiteSpace(description, nameof(description), "description required");
        ArgumentGuard.Positive(points, nameof(points), "must be positive");
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();

    public string GetName()
    {
        return _shortName;
    }

    public virtual int GetPointsForEvent()
    {
        if (!GoalGuard.CanRecord(this))
        {
            return 0;
        }

        return _points;
    }

    public virtual string GetDetailsString()
    {
        return $"[{(IsComplete() ? "x" : " ")}] {_shortName} ({_description}) points {_points}";
    }

    public abstract string GetStringRepresentation();

    protected string FormatRepresentation(string goalType, params object[] additionalFields)
    {
        List<string> fields = new List<string>
        {
            goalType,
            Uri.EscapeDataString(_shortName),
            Uri.EscapeDataString(_description),
            _points.ToString(System.Globalization.CultureInfo.InvariantCulture)
        };

        foreach (object field in additionalFields)
        {
            fields.Add(Convert.ToString(field, System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty);
        }

        return string.Join("|", fields);
    }
}
