using System;

public class Entry
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
