class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        if (reference is null)
        {
            throw new ArgumentNullException(nameof(reference));
        }

        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Scripture text cannot be empty.", nameof(text));
        }

        _reference = reference;

        foreach (string word in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        if (numberToHide < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(numberToHide),
                "Number of words to hide cannot be negative."
            );
        }

        List<Word> visibleWords = _words.FindAll(word => !word.IsHidden());
        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = Random.Shared.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.TrueForAll(word => word.IsHidden());
    }

    public string GetDisplayText()
    {
        string text = _reference.GetDisplayText();

        foreach (Word word in _words)
        {
            text += " " + word.GetDisplayText();
        }

        return text;
    }
}
