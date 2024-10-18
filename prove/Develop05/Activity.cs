using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} activity.");
        Console.WriteLine(_description);

        Console.Write("How long in seconds would you like the activity to last? ");
        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.WriteLine("Please enter a valid number of seconds greater than zero.");
        }

        Console.WriteLine("Get ready...");
        ShowProgressBar("Preparing", 3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You've completed the {_name} activity for {_duration} seconds.");
        ShowProgressBar("Finishing", 3);
    }

    protected void ShowProgressBar(string message, int duration, bool countdown = false)
    {
        int barLength = 30;
        for (int i = 0; i <= barLength; i++)
        {
            Console.Write($"\r{message} [{new string('=', i)}{new string(' ', barLength - i)}] ");
            if (countdown)
            {
                Console.Write($"{duration - (i * duration / barLength)}s ");
            }
            Thread.Sleep(duration * 1000 / barLength);
        }
        Console.WriteLine();
    }

    protected void ShowBreathingProgressBar(string message, int duration)
    {
        ShowProgressBar(message, duration);
    }
}