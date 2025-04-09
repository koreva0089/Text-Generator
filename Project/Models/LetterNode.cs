namespace Project.Models
{
    public class LetterNode : Node
    {
        public char Letter { get; set; }

        public LetterNode(char letter) : base()
        {
            Letter = letter;
        }
    }
}
