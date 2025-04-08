using System.Numerics;

namespace Project.Models
{
    public class Node
    {
        public string Text { get; set; }
        public int Count { get; set; }
        public List<int> NextIndeces { get; }

        public Node(string text)
        {
            Text = text;
            Count = 1;
            NextIndeces = new();
        }
    }
}
