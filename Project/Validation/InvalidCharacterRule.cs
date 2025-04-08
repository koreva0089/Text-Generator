using System.Globalization;
using System.Windows.Controls;

namespace Project.Validation
{
    public class InvalidCharacterRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var text = (string)value;
                if (text.Length > 0)
                {
                    int myvalue = int.Parse(text);
                    if (myvalue < 0)
                    {
                        return new ValidationResult(false, "Word count can't be less than 0");
                    }
                }
            }
            catch(Exception e)
            {
                return new ValidationResult(false, "Illegal character or " + e.Message);
            }

            return new ValidationResult(true, null);
        }
    }
}
