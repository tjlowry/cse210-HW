public class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(DateTime date, int lengthInMinutes, int laps) 
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Distance (miles) = swimming laps * 50 / 1000 * 0.62
        return _laps * 50 / 1000 * 0.62;
    }
}