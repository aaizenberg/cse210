using System;

class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _verse;
    private readonly int _endVerse;

    public Reference(
        string book,
        int chapter,
        int verse
    )
    {
        if (string.IsNullOrWhiteSpace(book))
        {
            throw new ArgumentException("Book cannot be empty", nameof(book));
        }

        if (chapter <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(chapter),
                "Chapter must be greater than zero"
            );
        }

        if (verse <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(verse),
                "Verse must be greater than zero"
            );
        }

        _book = book.Trim();
        _chapter = chapter;
        _verse = verse;
    }

    public Reference(
        string book,
        int chapter,
        int startVerse,
        int endVerse
    ) : this(book, chapter, startVerse)
    {
        if (endVerse < startVerse)
        {
            throw new ArgumentOutOfRangeException(
                nameof(endVerse),
                "End verse cannot be before the start verse"
            );
        }

        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse != 0)
            return _book + " " + _chapter + ":" + _verse + "-" + _endVerse;

        return _book + " " + _chapter + ":" + _verse;
    }
}
