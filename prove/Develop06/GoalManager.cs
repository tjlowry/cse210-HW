using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n1. Create Goal\n2. List Goals\n3. Record Event\n4. Display Score\n5. Save Goals\n6. Load Goals\n7. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    DisplayPlayerInfo();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Enter goal type (1. Simple, 2. Eternal, 3. Checklist): ");
        int goalType = int.Parse(Console.ReadLine());

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;
        switch (goalType)
        {
            case 1:
                newGoal = new SimpleGoal(name, description, points);
                break;
            case 2:
                newGoal = new EternalGoal(name, description, points);
                break;
            case 3:
                Console.Write("Enter target completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
        }
        _goals.Add(newGoal);
    }

    public void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }

        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        int pointsEarned = _goals[goalIndex].RecordEvent(); // Now RecordEvent returns points
        _score += pointsEarned;

        Console.WriteLine($"You earned {pointsEarned} points.");
    }


    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Your current score: {_score}");
    }

    public void SaveGoals()
    {
        Console.WriteLine("Saving goals...");
        // Code to save goals to a file
    }

    public void LoadGoals()
    {
        Console.WriteLine("Loading goals...");
        // Code to load goals from a file
    }
}
