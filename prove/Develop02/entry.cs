public class Entry
{
    public string _prompt;
    public string _response;
    public string _date;
    public string _whereDidYouGo;

    public Entry(string prompt, string response, string date, string whereDidYouGo)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
        _whereDidYouGo = whereDidYouGo;
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Where did you go today? {_whereDidYouGo}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine("-----------------------------------");
    }
}
