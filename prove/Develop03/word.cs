public class Word
{
    private string _text;
    private bool _isHidden;

    public string Text => _text;
    public bool IsHidden => _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Reveal()
    {
        _isHidden = false;
    }

    public override string ToString()
    {
        return _isHidden ? "_____" : _text;
    }
}