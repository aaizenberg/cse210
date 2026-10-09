class QuestMenu
{
    private readonly GoalManager _goalManager;

    public QuestMenu(GoalManager goalManager)
    {
        ArgumentGuard.NotNull(goalManager, nameof(goalManager));
        _goalManager = goalManager;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            _goalManager.DisplayPlayerInfo();
            Menu.ShowMainMenu();
            Console.Write("option ");
            string? input = Console.ReadLine();

            if (input is null)
            {
                break;
            }

            if (!InputGuard.TryNumber(input, 1, 6, out int choice))
            {
                continue;
            }

            try
            {
                switch (choice)
                {
                    case 1:
                        _goalManager.CreateGoal();
                        break;
                    case 2:
                        _goalManager.ListGoalDetails();
                        break;
                    case 3:
                        _goalManager.SaveGoals();
                        break;
                    case 4:
                        _goalManager.LoadGoals();
                        break;
                    case 5:
                        _goalManager.RecordEvent();
                        break;
                    case 6:
                        isRunning = false;
                        break;
                }
            }
            catch (EndOfStreamException)
            {
                break;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("file not found");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("folder not found");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("access denied");
            }
            catch (IOException)
            {
                Console.WriteLine("file error");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException)
            {
                Console.WriteLine("score limit");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("invalid value");
            }

            Console.WriteLine();
        }
    }
}
