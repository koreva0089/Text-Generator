using System.Globalization;
using System.Windows.Data;

namespace Project.Converters
{
    public class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString() ?? value;
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var strValue = value as string;
            if (strValue != null)
            {
                double result;
                var isConverted = double.TryParse(strValue, out result);
                if (isConverted)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
