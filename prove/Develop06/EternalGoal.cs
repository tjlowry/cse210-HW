public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent()
    {
        return _points; // Eternal goals always award points
    }

    public override bool IsComplete()
    {
        return false; // EternalGoal is never complete
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName},{_description},{_points},Eternal";
    }
}
