class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Word cannot be empty", nameof(text));
        }

        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        char[] displayCharacters = _text.ToCharArray();

        for (int i = 0; i < displayCharacters.Length; i++)
        {
            if (char.IsLetter(displayCharacters[i]))
            {
                displayCharacters[i] = '_';
            }
        }

        return new string(displayCharacters);
    }
}
