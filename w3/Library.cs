using System;

class Library
{
    private readonly List<Scripture> _scriptures = new List<Scripture>();

    public Library()
    {
        AddScripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever " +
            "believeth in him should not perish, but have everlasting life."
        );

        AddScripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
            "In all thy ways acknowledge him, and he shall direct thy paths."
        );

        AddScripture(
            new Reference("Psalm", 23, 1),
            "The Lord is my shepherd, I shall not want."
        );

        AddScripture(
            new Reference("Isaiah", 40, 31),
            "But they that wait upon the Lord shall renew their strength; they shall mount up " +
            "with wings as eagles; they shall run, and not be weary; and they shall walk, and not faint."
        );

        AddScripture(
            new Reference("Matthew", 11, 28),
            "Come unto me, all ye that labour and are heavy laden, and I will give you rest."
        );

        AddScripture(
            new Reference("Philippians", 4, 13),
            "I can do all things through Christ which strengtheneth me."
        );
    }

    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0)
        {
            throw new InvalidOperationException("The library contains no scriptures");
        }

        int index = Random.Shared.Next(_scriptures.Count);
        return _scriptures[index];
    }

    private void AddScripture(Reference reference, string text)
    {
        _scriptures.Add(new Scripture(reference, text));
    }
}
