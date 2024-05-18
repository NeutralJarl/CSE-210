using System;
using System.Collections.Generic;
using System.IO;

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
            "If I had one thing I could do over today, what would it be?",
            "What was the strongest emotion I felt today?",
            "What made me smile today?",
            "What am I grateful for today?",
            "What did I learn today?",
            "What is one thing I could improve about myself?",
            "What goal progress did I make today?",
            "What inspired me today?",
            "What challenged me today and how did I handle it?",
            "What am I looking forward to tomorrow?",
            "What did I do today to take care of myself?",
            "What was the highlight of my day?"
        };

        string choice;
        do
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Add a new prompt");
            Console.WriteLine("6. Remove a prompt");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Random random = new Random();
                    int randomIndex = random.Next(prompts.Count);
                    string randomPrompt = prompts[randomIndex];

                    Console.WriteLine("Your random writing prompt:");
                    Console.WriteLine(randomPrompt);
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(randomPrompt, response);
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
                    if (prompts.Count == 0)
                    {
                        Console.WriteLine("No prompts to remove.");
                        break;
                    }
                    Console.WriteLine("Current prompts:");
                    for (int i = 0; i < prompts.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {prompts[i]}");
                    }
                    Console.Write("Enter the number of the prompt to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int promptToRemove) && promptToRemove > 0 && promptToRemove <= prompts.Count)
                    {
                        prompts.RemoveAt(promptToRemove - 1);
                        Console.WriteLine("Prompt removed.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid prompt number.");
                    }
                    break;
                case "7":
                    Console.WriteLine("Exiting program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (choice != "7");
    }
}
