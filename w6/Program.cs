// creativity feature levels every 1000 points with progress and level up messages

class Program
{
    static void Main()
    {
        GoalManager goalManager = new GoalManager();
        QuestMenu menu = new QuestMenu(goalManager);
        menu.Run();
    }
}
