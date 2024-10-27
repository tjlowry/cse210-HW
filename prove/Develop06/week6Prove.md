Polymorphism means many forms and in coding it refers to the idea that a method can be used to perform many different tasks by slightly changing its form allowing us adapt the same idea to multiple places in the program. This is very useful and instead of making a seperate RecordEvent method for each goal type in the eternal quest program I was able to reuse the base on multiple times and adjust it based on the goal.

This increases code resuseability and also makes it simpler to change in the future because the use of a base method.


The code below shows an example of Polymorphism in my eternal quest program where the different goal types use the RecordEvent method but each use it differently due to how each goal is treated within the program.

public void RecordEvent()
{
    Console.Write("\nWhich goal did you accomplish? ");
    if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _goals.Count)
    {
        Goal selectedGoal = _goals[choice - 1];
        int points = selectedGoal.RecordEvent();
        _score += points;
    }
}

// Base Goal class
public abstract int RecordEvent();

// SimpleGoal implementation:
public override int RecordEvent()
{
    if (!_isComplete)
    {
        _isComplete = true;
        return _points;
    }
    return 0;
}

// EternalGoal implementation:
public override int RecordEvent()
{
    _timesCompleted++;
    return _points;
}

// ChecklistGoal implementation:
public override int RecordEvent()
{
    _amountCompleted++;
    if (_amountCompleted == _target)
    {
        return _points + _bonus;
    }
    return _points;
}