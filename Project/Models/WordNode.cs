namespace Project.Models
{
    public class WordNode : Node
    {
        public string Text { get; set; }

        public WordNode(string text) : base()
        {
            Text = text;
        }
    }
}
