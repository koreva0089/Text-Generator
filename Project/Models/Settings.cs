namespace Project.Models
{
    public class Settings
    {
        private GenerateType GenerateType { get; }

        public Settings(GenerateType generateType)
        {
            GenerateType = generateType;
        }
    }
}
