// The Word class represents a single word in the scripture, 
// keeping track of its text and whether it should be shown or hidden as underscores.
public class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false; // Words start visible by default
    }

    public void Hide() // Marks the word as hidden
    {
        _hidden = true;
    }

    public bool Hidden() // Returns whether the word is currently hidden
    {
        return _hidden;
    }

    public string DisplayText() // Returns the original text if visible, or underscores matching its length if hidden
    {
        if (_hidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}
