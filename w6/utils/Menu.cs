public static class Menu
{
    public static void ShowMainMenu()
    {
        Console.WriteLine("menu options");
        Console.WriteLine("1 create goal");
        Console.WriteLine("2 list goals");
        Console.WriteLine("3 save goals");
        Console.WriteLine("4 load goals");
        Console.WriteLine("5 record event");
        Console.WriteLine("6 quit");
    }

    public static void ShowGoalTypesMenu()
    {
        Console.WriteLine("goal types");
        Console.WriteLine("1 simple goal");
        Console.WriteLine("2 eternal goal");
        Console.WriteLine("3 checklist goal");
    }
}
