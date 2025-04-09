namespace Project.Models
{
    public abstract class Node
    {
        public int Count { get; set; }
        public List<int> NextIndices { get; }

        public Node()
        {
            Count = 1;
            NextIndices = new();
        }
    }
}
