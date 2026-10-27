namespace Assignment
{
    public class Writing : Assignment
    {
        private string _title = "";

        public string GetTitle()
        {
            return $"{_title}";
        }

        public void SetTitle(string title)
        {
            _title = title;
        }

        public string GetWritingInfo()
        {
            return $"{_studentName} - {_topic}\nTitle: {_title} by {_studentName} ";
        }
    }
}
