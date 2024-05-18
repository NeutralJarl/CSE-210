using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(string prompt, string response)
    {
        string promptResponse = $"{prompt}|||{response}";
        _entries.Add(new Entry(promptResponse, DateTime.Now));
    }

    public void DisplayEntries()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date},{entry.PromptResponse}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear(); // Clear existing entries
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            DateTime date = DateTime.Parse(parts[0]);
            string promptResponse = parts[1];
            _entries.Add(new Entry(promptResponse, date));
        }
    }
}
