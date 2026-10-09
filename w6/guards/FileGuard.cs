public static class FileGuard
{
    public static void ChecklistProgress(int completed, int target)
    {
        ValidFormat(completed >= 0 && completed <= target,
            "invalid progress");
    }

    public static void ValidFormat(bool condition, string message)
    {
        if (!condition)
        {
            throw new FormatException(message);
        }
    }

    public static int Integer(string? value, int minimum, string message)
    {
        ValidFormat(ArgumentGuard.TryInteger(value, out int number) && number >= minimum, message);
        return number;
    }

    public static bool Boolean(string value, string message)
    {
        bool valid = bool.TryParse(value, out bool result);
        ValidFormat(valid && !value.Contains('\0'), message);
        return result;
    }

    public static void GoalRecord(string[] fields)
    {
        ValidFormat(fields.Length >= 4, "invalid record");

        int expectedLength = fields[0] switch
        {
            nameof(SimpleGoal) => 5,
            nameof(EternalGoal) => 4,
            nameof(ChecklistGoal) => 7,
            _ => 0
        };

        ValidFormat(expectedLength > 0 && fields.Length == expectedLength,
            "invalid record");
    }
}
