public static class InputGuard
{
    public static bool TryText(string? input, out string value)
    {
        if (input is null)
        {
            throw new EndOfStreamException();
        }

        value = input.Trim();

        if (value.Length == 0)
        {
            Console.WriteLine("value required");
            return false;
        }

        return true;
    }

    public static bool TryNumber(string input, int minimum, int maximum, out int number)
    {
        if (!ArgumentGuard.TryInteger(input, out number))
        {
            Console.WriteLine("invalid number");
            return false;
        }

        if (number < minimum || number > maximum)
        {
            if (maximum == int.MaxValue)
            {
                Console.WriteLine(minimum == 0 ? "no negatives" : "must be positive");
            }
            else
            {
                Console.WriteLine($"number {minimum} to {maximum}");
            }

            return false;
        }

        return true;
    }
}
