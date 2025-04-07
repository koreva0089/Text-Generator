using Project.Models;
using System.Globalization;
using System.Windows.Data;

namespace Project.Converters
{
    public class GenerateTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var generateType = (GenerateType)value;

            switch (generateType)
            {
                case GenerateType.Words:
                    return "words";

                case GenerateType.Letters:
                    return "letters";
            }

            throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
