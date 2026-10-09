public static class ArgumentGuard
{
    public static bool TryInteger(string? value, out int number)
    {
        number = 0;
        return value is not null && !value.Contains('\0') &&
            int.TryParse(value, System.Globalization.NumberStyles.Integer,
                System.Globalization.CultureInfo.InvariantCulture, out number);
    }

    public static void NotNull(object? value, string parameterName)
    {
        ArgumentNullException.ThrowIfNull(value, parameterName);
    }

    public static void NotNullOrWhiteSpace(string value, string parameterName, string message)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(message, parameterName);
        }
    }

    public static void Positive(int value, string parameterName, string message)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(parameterName, message);
        }
    }

    public static void NonNegative(int value, string parameterName, string message)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(parameterName, message);
        }
    }
}
