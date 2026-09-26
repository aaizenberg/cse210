class Video
{
    private readonly List<Comment> _comments = new List<Comment>();

    public string Title { get; }
    public string Author { get; }
    public int LengthInSeconds { get; }

    public Video(string title, string author, int lengthInSeconds)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be empty", nameof(title));
        }

        if (string.IsNullOrWhiteSpace(author))
        {
            throw new ArgumentException("Author cannot be empt", nameof(author));
        }

        if (lengthInSeconds <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(lengthInSeconds),
                "need to be > 0 seconds"
            );
        }

        Title = title.Trim();
        Author = author.Trim();
        LengthInSeconds = lengthInSeconds;
    }

    public void AddComment(Comment comment)
    {
        ArgumentNullException.ThrowIfNull(comment);
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public string GetDisplayText()
    {
        List<string> lines = new List<string>
        {
            $"Title {Title}",
            $"Author {Author}",
            $"Length {LengthInSeconds} seconds",
            $"Comments ({GetNumberOfComments()})"
        };

        foreach (Comment comment in _comments)
        {
            lines.Add($"* {comment.GetDisplayText()}");
        }

        return string.Join(Environment.NewLine, lines);
    }
}
