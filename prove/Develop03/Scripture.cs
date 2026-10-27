// The Scriptures class manages the collection of Word objects
// for a specific scripture and handles the logic for hiding random words.
public class Scriptures
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scriptures(Reference reference, string text)
    {
        _reference = reference;
        
        // Split the string text into individual words and wrap each in a Word object
        string[] splitText = text.Split(' ');
        foreach (string wordText in splitText)
        {
            _words.Add(new Word(wordText));
        }
    }

    // Randomly selects visible words and hides them without infinite looping
    public void HideWords(Random random, int count)
    {
        int hiddenCount = 0;
        
        // Try to hide 'count' number of words
        while (hiddenCount < count && !IsCompletelyHidden())
        {
            int index = random.Next(_words.Count);
            
            // If the word isn't already hidden, hide it
            if (!_words[index].Hidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }
    
    // Combines the reference and all word display texts into a single string
    public string DisplayText()
    {
        string textOutput = "";
        foreach (Word word in _words)
        {
            textOutput += word.DisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()} {textOutput.Trim()}";
    }

    // Checks if every word in the scripture has been hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.Hidden())
            {
                return false; 
            }
        }
        return true; 
    }
}
