using System;

public class Cycling : Activity
{
    private readonly double _speedMph;

    public Cycling(DateOnly date, int minutes, double speedMph)
        : base(date, minutes, "cycling")
    {
        ActivityGuard.PositiveSpeed(speedMph);
        _speedMph = speedMph;
    }

    public override double GetDistance()
    {
        return _speedMph * GetMinutes() / 60;
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetPace()
    {
        return ActivityGuard.DivideSafely(60, GetSpeed());
    }
}
