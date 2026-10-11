using System;

public class Swimming : Activity
{
    private const double MilesPerLap = 50.0 / 1000.0 * 0.62;
    private readonly int _laps;

    public Swimming(DateOnly date, int minutes, int laps)
        : base(date, minutes, "swimming")
    {
        ActivityGuard.PositiveLaps(laps);
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * MilesPerLap;
    }

    public override double GetSpeed()
    {
        return ActivityGuard.DivideSafely(GetDistance(), GetMinutes(), 60);
    }

    public override double GetPace()
    {
        return ActivityGuard.DivideSafely(GetMinutes(), GetDistance());
    }
}
