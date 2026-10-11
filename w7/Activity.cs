using System;
using System.Globalization;

public abstract class Activity
{
    private readonly DateOnly _date;
    private readonly int _minutes;
    private readonly string _activityName;

    protected Activity(DateOnly date, int minutes, string activityName)
    {
        ActivityGuard.PositiveMinutes(minutes);

        _date = date;
        _minutes = minutes;
        _activityName = activityName;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public string GetSummary()
    {
        CultureInfo culture = CultureInfo.InvariantCulture;
        string date = _date.ToString("dd MMM yyyy", culture).ToLowerInvariant();
        string distance = GetDistance().ToString("F1", culture);
        string speed = GetSpeed().ToString("F1", culture);
        string pace = GetPace().ToString("F1", culture);

        return $"{date} {_activityName} {_minutes}min {distance}mi {speed}mph {pace}min/mi";
    }
}
