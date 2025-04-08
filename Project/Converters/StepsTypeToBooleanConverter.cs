using Project.Models;
using System.Globalization;
using System.Windows.Data;

namespace Project.Converters
{
    public class StepsTypeToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (StepsType)value;
            var id = (string)parameter;

            return type == StepsType.Order && id == "order"
                || type == StepsType.Chaotic && id == "chaotic";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isChecked = (bool)value;

            if (isChecked)
            {
                var id = (string)parameter;
                switch (id)
                {
                    case "order":
                        return StepsType.Order;

                    case "chaotic":
                        return StepsType.Chaotic;
                }
            }

            return 0;
        }
    }
}
