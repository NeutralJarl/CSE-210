public class Scripture
{
    private ScriptureReference _reference;
    private List<Word> _words;

    public ScriptureReference Reference => _reference;

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        var visibleWords = _words.Where(w => !w.IsHidden).ToList();

        if (!visibleWords.Any()) return;

        var wordsToHide = visibleWords.OrderBy(x => random.Next()).Take(count).ToList();

        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }

    public void RevealOneWord()
    {
        var hiddenWords = _words.Where(word => word.IsHidden).ToList();
        if (hiddenWords.Any())
        {
            var random = new Random();
            hiddenWords[random.Next(hiddenWords.Count)].Reveal();
        }
    }

    public int GetVisibleWordCount()
    {
        return _words.Count(word => !word.IsHidden);
    }

    public int GetTotalWordCount()
    {
        return _words.Count;
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden);
    }

    public override string ToString()
    {
        return $"{_reference}\n{string.Join(" ", _words)}";
    }
}