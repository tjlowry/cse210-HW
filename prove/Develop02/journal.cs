using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(string prompt, string response, string whereDidYouGo)
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        Entry newEntry = new Entry(prompt, response, date, whereDidYouGo);
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

                writer.WriteLine($"\"{entry._date}\",\"{safeWhereDidYouGo}\",\"{safePrompt}\",\"{safeResponse}\"");
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
            string whereDidYouGo = parts[2].Trim('"');
            string prompt = parts[5].Trim('"');
            string response = parts[6].Trim('"');

            Entry entry = new Entry(prompt, response, date, whereDidYouGo);
            _entries.Add(entry);
        }
    }

}
