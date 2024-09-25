using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(string prompt, string response, string mood, string whereDidYouGo, string bestPart, string worstPart)
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        Entry newEntry = new Entry(prompt, response, date, mood, whereDidYouGo, bestPart, worstPart);
        _entries.Add(newEntry);
    }


    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveJournal(string filename)
    {
        if (!filename.EndsWith(".csv"))
        {
            filename += ".csv";
        }

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                string safeResponse = entry._response.Replace("\"", "\"\"");
                string safePrompt = entry._prompt.Replace("\"", "\"\"");
                string safeWhereDidYouGo = entry._whereDidYouGo.Replace("\"", "\"\"");
                string safeBestPart = entry._bestPart.Replace("\"", "\"\"");
                string safeWorstPart = entry._worstPart.Replace("\"", "\"\"");
                string safeMood = entry._mood.Replace("\"", "\"\"");

                writer.WriteLine($"\"{entry._date}\",\"{safeMood}\",\"{safeWhereDidYouGo}\",\"{safeBestPart}\",\"{safeWorstPart}\",\"{safePrompt}\",\"{safeResponse}\"");
            }
        }

        Console.WriteLine($"Journal saved successfully to {filename}");
}


    public void LoadJournal(string filename)
    {
        _entries.Clear(); 
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');

            string date = parts[0].Trim('"');
            string mood = parts[1].Trim('"');
            string whereDidYouGo = parts[2].Trim('"');
            string bestPart = parts[3].Trim('"');
            string worstPart = parts[4].Trim('"');
            string prompt = parts[5].Trim('"');
            string response = parts[6].Trim('"');

            Entry entry = new Entry(prompt, response, date, mood, whereDidYouGo, bestPart, worstPart);
            _entries.Add(entry);
        }
    }

}
