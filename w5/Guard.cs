public static class Guard
{
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
}
