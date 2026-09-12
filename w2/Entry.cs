using System;

class Entry
{
    private readonly string _date;
    private readonly string _promptText;
    private readonly string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine(_entryText);
    }

    public string ToFileString()
    {
        return string.Join(" | ", _date, _promptText, _entryText);
    }

    public static Entry FromFileString(string fileLine)
    {
        string[] parts = fileLine.Split('|', 3);

        if (parts.Length != 3)
        {
            throw new FormatException("Each entry must contain a date, prompt, and response");
        }

        return new Entry(parts[0], parts[1], parts[2]);
    }

    public bool Contains(string searchText)
    {
        return _date.Contains(searchText, StringComparison.OrdinalIgnoreCase)
            || _promptText.Contains(searchText, StringComparison.OrdinalIgnoreCase)
            || _entryText.Contains(searchText, StringComparison.OrdinalIgnoreCase);
    }
}
