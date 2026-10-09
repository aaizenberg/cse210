public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\npoints {_score}");
        Console.WriteLine($"level {LevelSystem.GetLevel(_score)}");
        Console.WriteLine($"next level {LevelSystem.GetPointsToNextLevel(_score)}\n");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1} {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (!GoalGuard.HasGoals(_goals.Count, "no goals"))
        {
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1} {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Menu.ShowGoalTypesMenu();
        int type = ReadNumber("goal type ", 1, 3);
        string name = ReadText("name ");
        string description = ReadText("description ");
        int points = ReadNumber("points ", 1);
        Goal goal;
        if (type == 1)
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (type == 2)
        {
            goal = new EternalGoal(name, description, points);
        }
        else
        {
            int target = ReadNumber("target ", 1);
            int bonus = ReadNumber("bonus ", 0);
            goal = new ChecklistGoal(name, description, points, target, bonus);
        }
        _goals.Add(goal);
        Console.WriteLine("goal created");
    }

    public void RecordEvent()
    {
        if (!GoalGuard.HasGoals(_goals.Count, "create goal first"))
        {
            return;
        }
        ListGoalNames();
        Goal goal = _goals[ReadNumber("goal number ", 1, _goals.Count) - 1];
        if (!GoalGuard.CanRecord(goal, "already complete"))
        {
            return;
        }
        int earned = goal.GetPointsForEvent();
        int newScore = checked(_score + earned);
        int previousScore = _score;
        goal.RecordEvent();
        _score = newScore;
        Console.WriteLine($"earned {earned}");
        LevelSystem.Celebrate(previousScore, _score);
    }

    public void SaveGoals()
    {
        string path = ReadText("filename ");
        var lines = new List<string> { _score.ToString(System.Globalization.CultureInfo.InvariantCulture) };
        lines.AddRange(_goals.Select(goal => goal.GetStringRepresentation()));
        File.WriteAllLines(path, lines);
        Console.WriteLine("goals saved");
    }

    public void LoadGoals()
    {
        string path = ReadText("filename ");
        string[] lines = File.ReadAllLines(path);
        int score = FileGuard.Integer(lines.FirstOrDefault(), 0,
            "invalid score");
        var goals = new List<Goal>();
        foreach (string line in lines.Skip(1))
        {
            string[] fields = line.Split('|');
            FileGuard.GoalRecord(fields);
            string name = Uri.UnescapeDataString(fields[1]);
            string description = Uri.UnescapeDataString(fields[2]);
            int points = FileGuard.Integer(fields[3], 1, "invalid points");
            Goal goal;
            switch (fields[0])
            {
                case "SimpleGoal":
                    goal = new SimpleGoal(name, description, points);
                    if (FileGuard.Boolean(fields[4], "invalid completion"))
                    {
                        goal.RecordEvent();
                    }
                    break;
                case "ChecklistGoal":
                    int target = FileGuard.Integer(fields[4], 1, "invalid target");
                    int bonus = FileGuard.Integer(fields[5], 0, "invalid bonus");
                    int completed = FileGuard.Integer(fields[6], 0, "invalid progress");
                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                    checklistGoal.RestoreProgress(completed);
                    goal = checklistGoal;
                    break;
                default:
                    goal = new EternalGoal(name, description, points);
                    break;
            }
            goals.Add(goal);
        }
        _goals = goals;
        _score = score;
        Console.WriteLine("goals loaded");
    }

    private static string ReadText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (InputGuard.TryText(Console.ReadLine(), out string value))
            {
                return value;
            }
        }
    }

    private static int ReadNumber(string prompt, int minimum, int maximum = int.MaxValue)
    {
        while (true)
        {
            string value = ReadText(prompt);
            if (InputGuard.TryNumber(value, minimum, maximum, out int number))
            {
                return number;
            }
        }
    }
}
