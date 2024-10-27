public abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    { 
        // Speed (mph or kph) = (distance / minutes) * 60
        return GetDistance() / _lengthInMinutes * 60;
    }

    public virtual double GetPace()
    {
        // Pace = 60 / speed
        return 60 / GetSpeed();
    }

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name.Replace("Activity", "")} ({_lengthInMinutes} min)- " +
               $"Distance {GetDistance():F1} miles, " +
               $"Speed {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile";
    }

    protected int GetLengthInMinutes()
    {
        return _lengthInMinutes;
    }
}