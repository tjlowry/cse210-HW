public class Entry
{
    public string _prompt;
    public string _response;
    public string _date;
    public string _mood;
    public string _whereDidYouGo;
    public string _bestPart;
    public string _worstPart;

    // Constructor
    public Entry(string prompt, string response, string date, string mood, string whereDidYouGo, string bestPart, string worstPart)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
        _mood = mood;
        _whereDidYouGo = whereDidYouGo;
        _bestPart = bestPart;
        _worstPart = worstPart;
    }

    // Method to display the entry
    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Where did you go today? {_whereDidYouGo}");
        Console.WriteLine($"Best part of the day: {_bestPart}");
        Console.WriteLine($"Worst part of the day: {_worstPart}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine("-----------------------------------");
    }
}
