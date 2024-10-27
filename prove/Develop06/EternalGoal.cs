using System;

public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        _timesCompleted = 0;
    }

    public int GetTimesCompleted()
    {
        return _timesCompleted;
    }

    public override int RecordEvent()
    {
        _timesCompleted++;
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        string timesText = _timesCompleted == 1 ? "time" : "times";
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description}) -- Completed {_timesCompleted} {timesText}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName}|{_description}|{_points}|{_timesCompleted}";
    }
}