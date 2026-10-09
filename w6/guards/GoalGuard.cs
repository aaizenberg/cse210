public static class GoalGuard
{
    public static bool HasGoals(int count, string message)
    {
        if (count == 0)
        {
            Console.WriteLine(message);
            return false;
        }

        return true;
    }

    public static bool CanRecord(Goal goal, string? message = null)
    {
        ArgumentGuard.NotNull(goal, nameof(goal));

        if (goal.IsComplete())
        {
            if (message is not null)
            {
                Console.WriteLine(message);
            }

            return false;
        }

        return true;
    }
}
