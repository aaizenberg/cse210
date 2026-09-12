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

    public void SaveToFile(string fileName)
    {
        File.WriteAllLines(fileName, _entries.Select(entry => entry.ToFileString()));
    }

    public void LoadFromFile(string fileName)
    {
        _entries.Clear();

        foreach (string fileLine in File.ReadLines(fileName))
        {
            _entries.Add(Entry.FromFileString(fileLine));
        }
    }
}
