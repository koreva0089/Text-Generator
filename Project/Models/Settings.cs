namespace Project.Models
{
    public class Settings
    {
        public GenerateType GenerateType { get; }

        public Settings(GenerateType generateType)
        {
            GenerateType = generateType;
        }
    }
}
