class Comment
{
    public string CommenterName { get; }
    public string Text { get; }

    public Comment(string commenterName, string text)
    {
        if (string.IsNullOrWhiteSpace(commenterName))
        {
            throw new ArgumentException("Commenter name cannot be empt", nameof(commenterName));
        }

        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Comment text cannot be empty", nameof(text));
        }

        CommenterName = commenterName.Trim();
        Text = text.Trim();
    }

    public string GetDisplayText()
    {
        return $"{CommenterName} {Text}";
    }
}
