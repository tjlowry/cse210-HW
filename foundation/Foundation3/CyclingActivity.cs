public class CyclingActivity : Activity
{
    private double _speed;

    public CyclingActivity(DateTime date, int lengthInMinutes, double speed) 
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetDistance()
    {
        return GetSpeed() * GetLengthInMinutes() / 60;
    }

    public override double GetPace()
    {
        return 60 / GetSpeed();
    }
}