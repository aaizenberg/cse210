public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        ArgumentGuard.Positive(target, nameof(target), "must be positive");
        ArgumentGuard.NonNegative(bonus, nameof(bonus), "no negatives");
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (GoalGuard.CanRecord(this))
        {
            _amountCompleted++;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted == _target;
    }

    public override int GetPointsForEvent()
    {
        int points = base.GetPointsForEvent();

        if (points == 0)
        {
            return 0;
        }

        if (_amountCompleted + 1 == _target)
        {
            return checked(points + _bonus);
        }

        return points;
    }

    internal void RestoreProgress(int amountCompleted)
    {
        FileGuard.ChecklistProgress(amountCompleted, _target);
        _amountCompleted = amountCompleted;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} progress {_amountCompleted}/{_target} bonus {_bonus}";
    }

    public override string GetStringRepresentation()
    {
        return FormatRepresentation(nameof(ChecklistGoal), _target, _bonus, _amountCompleted);
    }
}
