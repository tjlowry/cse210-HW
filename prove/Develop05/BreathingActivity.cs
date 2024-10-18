public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") {}

    public void Run()
    {   
        DisplayStartingMessage();
        Console.WriteLine();
        
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            if (DateTime.Now.AddSeconds(8) <= endTime)
            {
                ShowBreathingProgressBar("Breathe in...", 4);
                ShowBreathingProgressBar("Breathe out...", 4);
            }
            else
            {
                int remainingSeconds = (int)(endTime - DateTime.Now).TotalSeconds;
                if (remainingSeconds > 0)
                {
                    ShowBreathingProgressBar("Breathe in...", remainingSeconds / 2);
                    ShowBreathingProgressBar("Breathe out...", remainingSeconds - (remainingSeconds / 2));
                }
                break;
            }
        }
        
        Console.WriteLine();
        DisplayEndingMessage();
    }
}