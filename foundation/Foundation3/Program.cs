using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new()
        {
            new RunningActivity(new DateTime(2022, 11, 3), 30, 3.0),
            new CyclingActivity(new DateTime(2022, 11, 3), 45, 15.0),
            new SwimmingActivity(new DateTime(2022, 11, 3), 40, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}