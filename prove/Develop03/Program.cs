public class Program
{
    static void Main(string[] args)
    {
        var scriptures = LoadScripturesFromFile("scriptures.txt");
        var selectedScripture = SelectScripture(scriptures);

        if (selectedScripture == null)
        {
            Console.WriteLine("No scripture selected. Exiting.");
            return;
        }

        bool quit = false;

        while (!quit)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(selectedScripture);
                Console.WriteLine($"\nWords visible: {selectedScripture.GetVisibleWordCount()} / {selectedScripture.GetTotalWordCount()}");
                Console.WriteLine("Press Enter to hide words, type 'hint' for a hint, or type 'quit' to select another scripture.");
                string input = Console.ReadLine();

                if (input.Trim().ToLower() == "quit")
                    break;

                if (input.Trim().ToLower() == "hint")
                {
                    selectedScripture.RevealOneWord();
                }
                else
                {
                    selectedScripture.HideRandomWords(3);
                }

                if (selectedScripture.AllWordsHidden())
                {
                    Console.Clear();
                    Console.WriteLine(selectedScripture);
                    Console.WriteLine("\nYou've hidden all the words. Good job!");
                    break;
                }
            }

            Console.WriteLine("Press Enter to select another scripture, or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.Trim().ToLower() == "quit")
                quit = true;
            else
                selectedScripture = SelectScripture(scriptures);
        }
    }

    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        var scriptures = new List<Scripture>();
        var lines = File.ReadAllLines(filePath);

        for (int i = 0; i < lines.Length; i += 3)
        {
            var referenceParts = lines[i].Split(' ');
            var book = referenceParts[0];
            var chapterVerse = referenceParts[1].Split(':');
            var chapter = int.Parse(chapterVerse[0]);
            var verses = chapterVerse[1].Split('-');
            var startVerse = int.Parse(verses[0]);
            var endVerse = verses.Length > 1 ? int.Parse(verses[1]) : startVerse;
            var reference = new ScriptureReference(book, chapter, startVerse, endVerse);
            var text = lines[i + 1];

            scriptures.Add(new Scripture(reference, text));
        }

        return scriptures;
    }

    static Scripture SelectScripture(List<Scripture> scriptures)
    {
        Console.WriteLine("Select a scripture to memorize:");

        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].Reference}");
        }

        int selection = -1;
        while (selection < 1 || selection > scriptures.Count)
        {
            Console.Write("Enter the number of the scripture: ");
            if (int.TryParse(Console.ReadLine(), out selection) && selection >= 1 && selection <= scriptures.Count)
            {
                return scriptures[selection - 1];
            }
            Console.WriteLine("Invalid selection. Please try again.");
        }

        return null; 
    }
}