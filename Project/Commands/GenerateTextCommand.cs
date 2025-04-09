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

            StringBuilder str = new();
            Random random = new();

            if (mainViewModel.Settings.GenerateType == GenerateType.Words)
            {
                List<WordNode> database = new();
                string[] data = mainViewModel.TextToGenerate.Split([' ', '.', ','], StringSplitOptions.RemoveEmptyEntries);

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
                            database[k].NextIndices.Add(j);
                        }
                    }
                }

                // Add next index to first word to prevent error
                database[j].NextIndices.Add(0);

                // Build generated text from structure by steps
                WordNode node;
                int nextIndex = 0;

                if (mainViewModel.Settings.StepsType == StepsType.Order)
                {
                    for (int i = 0; i < mainViewModel.Settings.Count - 1; i++)
                    {
                        node = database[nextIndex];
                        str.Append(node.Text + ' ');
                        nextIndex = node.NextIndices[random.Next(node.Count)];
                    }

                    node = database[nextIndex];
                    str.Append(node.Text);
                }
                else
                {
                    // Generate text in chaotic order which means it doesn't
                    // matter what word is after one another
                    for (int i = 0; i < mainViewModel.Settings.Count - 1; i++)
                    {
                        nextIndex = random.Next(database.Count);
                        node = database[nextIndex];
                        str.Append(node.Text + ' ');
                    }

                    nextIndex = random.Next(database.Count);
                    node = database[nextIndex];
                    str.Append(node.Text);
                }

                mainViewModel.GeneratedText = str.ToString();

#if DEBUG
                // Using same StringBuilder for debug purposes
                str.Clear();

                str.AppendLine("Generate type: " +
                    $"{(mainViewModel.Settings.GenerateType == GenerateType.Words ? "Words" : "Letters")}");
                str.AppendLine($"Count to generate: {mainViewModel.Settings.Count}");
                str.AppendLine("Steps type: " +
                    $"{(mainViewModel.Settings.StepsType == StepsType.Order ? "Order" : "Chaotic")}\n");

                str.Append("Structure: {");
                for (int i = 0; i < database.Count - 1; i++)
                {
                    str.Append($"{database[i].Text}, ");
                }
                str.AppendLine($"{database.Last().Text}}}\n");

                for (int i = 0; i < database.Count; i++)
                {
                    str.Append($"{i}. {database[i].Count} = {database[i].Text} -> {{");

                    for (int k = 0; k < database[i].NextIndices.Count - 1; k++)
                    {
                        str.Append($"{database[i].NextIndices[k]}, ");
                    }

                    if (database[i].NextIndices.Count > 0)
                    {
                        str.Append(database[i].NextIndices.Last());
                    }

                    str.AppendLine("}");
                }

                MessageBox.Show(str.ToString());
#endif
            }
            else
            {
                // Generate text by letters
                List<LetterNode> database = new();
                string textToGen = mainViewModel.TextToGenerate.ToLower();

                database.Add(new(textToGen[0]));

                int index = 0;
                for (int i = 1; i < textToGen.Length; i++)
                {
                    bool contains = false;

                    index = 0;
                    for(; index < database.Count; index++)
                    {
                        if (textToGen[i] == database[index].Letter)
                        {
                            contains = true;
                            break;
                        }
                    }

                    if (contains)
                    {
                        database[index].Count++;
                    }
                    else
                    {
                        database.Add(new(textToGen[i]));
                    }

                    for(int j = 0; j < database.Count; j++)
                    {
                        if (database[j].Letter == textToGen[i - 1])
                        {
                            database[j].NextIndices.Add(index);
                        }
                    }
                }

                database[index].NextIndices.Add(0);

                // Generate text based on characters on structure
                LetterNode node;
                int nextIndex = 0;

                if (mainViewModel.Settings.StepsType == StepsType.Order)
                {
                    for (int i = 0; i < mainViewModel.Settings.Count; i++)
                    {
                        node = database[nextIndex];
                        str.Append(node.Letter);
                        nextIndex = node.NextIndices[random.Next(node.Count)];
                    }
                }
                else
                {
                    for (int i = 0; i < mainViewModel.Settings.Count; i++)
                    {
                        nextIndex = random.Next(database.Count);
                        node = database[nextIndex];
                        str.Append(node.Letter);
                    }
                }

                mainViewModel.GeneratedText = str.ToString();
#if DEBUG
                    str.Clear();

                str.Append("Structure: {");
                for (int i = 0; i < database.Count - 1; i++)
                {
                    str.Append($"{database[i].Letter}, ");
                }
                str.AppendLine($"{database.Last().Letter}}}\n");

                for (int i = 0; i < database.Count; i++)
                {
                    str.Append($"{i}. {database[i].Letter} -> {{");
                    for (int j = 0; j < database[i].NextIndices.Count - 1; j++)
                    {
                        str.Append($"{database[i].NextIndices[j]}, ");
                    }
                    str.AppendLine($"{database[i].NextIndices.Last()}}}");
                }

                MessageBox.Show(str.ToString());
#endif
            }
        }
    }
}
