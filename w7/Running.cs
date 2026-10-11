using System;

public class Running : Activity
{
    private readonly double _distanceMiles;

    public Running(DateOnly date, int minutes, double distanceMiles)
        : base(date, minutes, "running")
    {
        ActivityGuard.PositiveDistance(distanceMiles);
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
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
