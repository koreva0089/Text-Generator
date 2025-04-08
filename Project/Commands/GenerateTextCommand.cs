using Project.Models;
using Project.ViewModel;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace Project.Commands
{
    public class GenerateTextCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;

        public GenerateTextCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;

            this.mainViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(mainViewModel.TextToGenerate))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(mainViewModel.TextToGenerate) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            //mainViewModel.GeneratedText = mainViewModel.TextToGenerate;
            // Build up a structure with unique words and next indices which
            // direction is next words in structure
            List<Node> database = new();
            string[] data = mainViewModel.TextToGenerate.Split([' ', '.', ','], StringSplitOptions.RemoveEmptyEntries);

            if (mainViewModel.Settings.GenerateType == GenerateType.Words)
            {
                data[0] = data[0].ToLower();
                database.Add(new(data[0]));

                int j = 0;
                for (int i = 1; i < data.Length; i++)
                {
                    j = 0;
                    bool contains = false;
                    for (; j < database.Count; j++)
                    {
                        if (database[j].Text == data[i])
                        {
                            contains = true;
                            break;
                        }
                    }

                    if (contains)
                    {
                        database[j].Count++;
                    }
                    else
                    {
                        database.Add(new(data[i].ToLower()));
                    }

                    for (int k = 0; k < database.Count; k++)
                    {
                        if (database[k].Text == data[i - 1])
                        {
                            database[k].NextIndeces.Add(j);
                        }
                    }
                }

                // Add next index to first word to prevent error
                database[j].NextIndeces.Add(0);

#if DEBUG
                StringBuilder str = new();

                str.AppendLine("Generate type: " +
                    $"{(mainViewModel.Settings.GenerateType == GenerateType.Words ? "Words" : "Letters")}");
                str.AppendLine($"Count to generate: {mainViewModel.Settings.Count}");
                str.AppendLine("Steps type: " +
                    $"{(mainViewModel.Settings.StepsType == StepsType.Order ? "Order" : "Chaotic")}\n");

                str.Append("Structure: {");
                for(int i = 0; i < database.Count - 1; i++)
                {
                    str.Append($"{database[i].Text}, ");
                }
                str.AppendLine($"{database.Last().Text}}}\n");

                for (int i = 0; i < database.Count; i++)
                {
                    str.Append($"{i}. {database[i].Count} = {database[i].Text} -> {{");

                    for(int k = 0; k < database[i].NextIndeces.Count - 1; k++)
                    {
                        str.Append($"{database[i].NextIndeces[k]}, ");
                    }

                    if (database[i].NextIndeces.Count > 0)
                    {
                        str.Append(database[i].NextIndeces.Last());
                    }

                    str.AppendLine("}");
                }

                MessageBox.Show(str.ToString());
#endif
            }
        }
    }
}
