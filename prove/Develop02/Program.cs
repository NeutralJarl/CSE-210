using System;
using System.Collections.Generic;
using System.IO;

//journal entries
class Entry
{
    public string PromptResponse { get; set; }
    public DateTime Date { get; set; }

    public Entry(string promptResponse, DateTime date)
    {
        PromptResponse = promptResponse;
        Date = date;
    }

    public override string ToString()
    {
        string[] parts = PromptResponse.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
        return $"{Date}: {parts[0]}\nResponse: {parts[1]}\n";
    }
}

// Journal itself
class Journal
{
    private List<Entry> entries = new List<Entry>();

    // Add a new entry to the journal
    public void AddEntry(string prompt, string response)
    {
        string promptResponse = $"{prompt}|||{response}";
        entries.Add(new Entry(promptResponse, DateTime.Now));
    }

    // Display all entries in the journal
    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    // Save the journal to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.PromptResponse}");
            }
        }
    }

    // Load entries from a file
    public void LoadFromFile(string filename)
    {
        entries.Clear(); // Clear existing entries
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            DateTime date = DateTime.Parse(parts[0]);
            string promptResponse = parts[1];
            entries.Add(new Entry(promptResponse, date));
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        List<string> prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        string choice;

        do
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Add more prompts");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Select a prompt:");
                    for (int i = 0; i < prompts.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {prompts[i]}");
                    }
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    Console.Write("Enter the prompt number: ");
                    int promptNumber = int.Parse(Console.ReadLine());
                    string selectedPrompt = prompts[promptNumber - 1];
                    journal.AddEntry(selectedPrompt, response);
                    break;
                case "2":
                    Console.WriteLine("Journal Entries:");
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter the filename to save to: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter the filename to load from: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    Console.WriteLine("Enter a new prompt:");
                    string newPrompt = Console.ReadLine();
                    prompts.Add(newPrompt);
                    break;
                case "6":
                    Console.WriteLine("Exiting program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (choice != "6");
    }
}
