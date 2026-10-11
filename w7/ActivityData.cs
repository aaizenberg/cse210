using System;
using System.Collections.Generic;

public static class ActivityData
{
    public static List<Activity> GetActivities()
    {
        DateOnly date = new(2022, 11, 3);

        return new List<Activity>
        {
            new Running(date, 30, 3.0),
            new Cycling(date, 30, 10.0),
            new Swimming(date, 30, 40)
        };
    }
}
