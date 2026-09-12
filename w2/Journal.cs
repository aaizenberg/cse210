using System;

class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SearchEntries(string searchText)
    {
        List<Entry> matchingEntries = _entries
            .Where(entry => entry.Contains(searchText))
            .ToList();

        if (matchingEntries.Count == 0)
        {
            Console.WriteLine("Not found");
            return;
        }

        foreach (Entry entry in matchingEntries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string fileName)
    {
        File.WriteAllLines(fileName, _entries.Select(entry => entry.ToFileString()));
    }

    public void LoadFromFile(string fileName)
    {
        try
        {
            List<Entry> loadedEntries = new List<Entry>();

            foreach (string fileLine in File.ReadLines(fileName))
            {
                loadedEntries.Add(Entry.FromFileString(fileLine));
            }

            _entries.Clear();
            _entries.AddRange(loadedEntries);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
    }
}
