using System;

public static class ActivityGuard
{
    public static void PositiveMinutes(int minutes)
    {
        if (minutes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(minutes), "bad time");
        }
    }

    public static void PositiveDistance(double distanceMiles)
    {
        if (!double.IsFinite(distanceMiles) || distanceMiles <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(distanceMiles), "bad distance");
        }
    }

    public static void PositiveSpeed(double speedMph)
    {
        if (!double.IsFinite(speedMph) || speedMph <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(speedMph), "bad speed");
        }
    }

    public static void PositiveLaps(int laps)
    {
        if (laps <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(laps), "bad laps");
        }
    }

    public static double DivideSafely(double numerator, double denominator, double multiplier = 1.0)
    {
        if (!double.IsFinite(numerator) ||
            !double.IsFinite(denominator) || denominator <= 0 ||
            !double.IsFinite(multiplier) || multiplier <= 0)
        {
            throw new InvalidOperationException("bad values");
        }

        double result = numerator / denominator * multiplier;
        if (!double.IsFinite(result))
        {
            throw new InvalidOperationException("bad result");
        }

        return result;
    }
}
