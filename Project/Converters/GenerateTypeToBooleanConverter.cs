using Project.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Project.Converters
{
    public class GenerateTypeToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var generateType = (GenerateType)value;
            var id = (string)parameter;

            return generateType == GenerateType.Words && id == "words"
                || generateType == GenerateType.Letters && id == "letters";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isChecked = (bool)value;

            if (isChecked)
            {
                var id = (string)parameter;
                switch (id)
                {
                    case "words":
                        return GenerateType.Words;

                    case "letters":
                        return GenerateType.Letters;
                }
            }

            return 0;
        }
    }
}
