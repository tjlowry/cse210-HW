public class RunningActivity : Activity
{
    private double _distance;

    public RunningActivity(DateTime date, int lengthInMinutes, double distance) 
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }
}