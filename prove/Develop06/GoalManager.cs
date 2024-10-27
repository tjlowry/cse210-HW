using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");

        int simpleCompleted = _goals.Count(g => g is SimpleGoal && g.IsComplete());
        
        int eternalCompleted = _goals
            .Where(g => g is EternalGoal)
            .Sum(g => ((EternalGoal)g).GetTimesCompleted());

        int checklistTotal = _goals
            .Where(g => g is ChecklistGoal)
            .Sum(g => ((ChecklistGoal)g).GetCompletionCount());

        Console.WriteLine("\nCompleted Goals Summary:");
        Console.WriteLine($"Simple Goals Completed: {simpleCompleted}");
        Console.WriteLine($"Eternal Goals Recorded: {eternalCompleted}");
        Console.WriteLine($"Checklist Goals Total Completions: {checklistTotal}");
    }


    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        
        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal;
        switch (goalType)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        _goals.Add(newGoal);
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals available to record.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        ListGoalNames();
        
        Console.Write("\nWhich goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _goals.Count)
        {
            Goal selectedGoal = _goals[choice - 1];
            int points = selectedGoal.RecordEvent();
            _score += points;
            
            Celebrate(selectedGoal, points);
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    public void SaveGoals()
    {
        Console.Write("\nWhat is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public void LoadGoals()
    {
        Console.Write("\nWhat is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        
        if (lines.Length > 0)
        {
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string[] data = parts[1].Split('|');

                switch (parts[0])
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2])));
                        if (bool.Parse(data[3])) _goals.Last().RecordEvent();
                        break;
                    case "EternalGoal":
                        EternalGoal eternal = new EternalGoal(data[0], data[1], int.Parse(data[2]));
                        _goals.Add(eternal);
                        int timesCompleted = int.Parse(data[3]);
                        for (int j = 0; j < timesCompleted; j++)
                        {
                            eternal.RecordEvent();
                        }
                        break;
                    case "ChecklistGoal":
                        ChecklistGoal goal = new ChecklistGoal(
                            data[0], data[1], int.Parse(data[2]), 
                            int.Parse(data[3]), int.Parse(data[4])
                        );
                        _goals.Add(goal);
                        int completedTimes = int.Parse(data[5]);
                        for (int j = 0; j < completedTimes; j++)
                        {
                            goal.RecordEvent();
                        }
                        break;
                }
            }
        }

        Console.WriteLine("Goals loaded successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    private void ShowFireworks()
    {
        string[] fireworks = new string[]
        {
            @"
                                   
                                   
                                   
                                   
                .                  
                                   
                                   ",

            @"
                                   
                                   
                                   
                |                  
                *                  
                                   
                                   ",

            @"
                                   
                                   
             . * .                 
                |                  
                *                  
                                   
                                   ",

            @"
                                   
            .    *    .            
               * * *               
                |                  
                *                  
                                   
                                   ",

            @"
                                   
           \ .  *  . /            
             * *** *              
                |                  
                *                  
                                   
                                   ",

            @"
            *     *     *          
           \ .  * *  . /          
             * *** *              
                                   
                                   
                                   
                                   ",

            @"
          * *     *     * *        
           \ .  * *  . /          
             * *** *              
                                   
                                   
                                   
                                   ",
        };

        ConsoleColor[] colors = new ConsoleColor[]
        {
            ConsoleColor.Red,
            ConsoleColor.Yellow,
            ConsoleColor.Magenta,
            ConsoleColor.Cyan,
            ConsoleColor.Green
        };

        Random rand = new Random();
        
        int originalLeft = Console.CursorLeft;
        int originalTop = Console.CursorTop;

        for (int firework = 0; firework < 3; firework++)
        {
            ConsoleColor randomColor = colors[rand.Next(colors.Length)];
            int xOffset = rand.Next(0, 40);

            foreach (string frame in fireworks)
            {
                Console.SetCursorPosition(originalLeft, originalTop);
                ConsoleColor originalColor = Console.ForegroundColor;
                Console.ForegroundColor = randomColor;
                string[] lines = frame.Split('\n');
                foreach (string line in lines)
                {
                    Console.SetCursorPosition(originalLeft + xOffset, Console.CursorTop);
                    Console.WriteLine(line);
                }

                Console.ForegroundColor = originalColor;
                Thread.Sleep(100);
            }
        }

        Console.SetCursorPosition(originalLeft, originalTop + 8);
    }

    private void Celebrate(Goal goal, int points)
    {
        Console.Clear();
        Console.WriteLine($"\nCongratulations! You have earned {points} points!");
        Console.WriteLine($"You now have {_score} points.\n");

        if (goal is SimpleGoal && goal.IsComplete())
        {
            Console.WriteLine("🎉 SIMPLE GOAL COMPLETED! 🎉");
            ShowFireworks();
        }
        else if (goal is EternalGoal)
        {
            Console.WriteLine($"⭐ ETERNAL GOAL RECORDED! ⭐");
            Console.WriteLine($"You've recorded this {((EternalGoal)goal).GetTimesCompleted()} times!");
            ShowFireworks();
        }
        else if (goal is ChecklistGoal)
        {
            ChecklistGoal checklistGoal = (ChecklistGoal)goal;
            if (checklistGoal.IsComplete())
            {
                Console.WriteLine("🎊 CHECKLIST GOAL COMPLETED! 🎊");
                Console.WriteLine("Bonus points awarded! 🌟");
                ShowFireworks();
            }
            else
            {
                Console.WriteLine("🌟 Making progress on your checklist goal! 🌟");
            }
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}