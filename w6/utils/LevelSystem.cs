public static class LevelSystem
{
    private const int _pointsPerLevel = 1000;

    public static int GetLevel(int score)
    {
        ArgumentGuard.NonNegative(score, nameof(score), "no negatives");
        return score / _pointsPerLevel + 1;
    }

    public static int GetPointsToNextLevel(int score)
    {
        ArgumentGuard.NonNegative(score, nameof(score), "no negatives");
        return _pointsPerLevel - score % _pointsPerLevel;
    }

    public static void Celebrate(int previousScore, int currentScore)
    {
        int previousLevel = GetLevel(previousScore);
        int currentLevel = GetLevel(currentScore);

        if (currentLevel > previousLevel)
        {
            Console.WriteLine($"level up {currentLevel}");
        }
    }
}
