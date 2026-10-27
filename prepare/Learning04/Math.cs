namespace Assignment
{
    public class Math : Assignment
    {
        private string _textbookSection = "";
        private string _problems = "";

        public string GetSection()
        {
            return $"{_textbookSection}";
        }

        public void SetSection(string textbookSection)
        {
            _textbookSection = textbookSection;
        }

        public string GetProblems()
        {
            return $"{_problems}";
        }

        public void SetProblems(string problems)
        {
            _problems = problems;
        }

        public string GetHomeWorkList()
        {
            return $"{_studentName} - {_topic}\nSection: {_textbookSection}, Problem(s): {_problems}";
        }
    }
}
