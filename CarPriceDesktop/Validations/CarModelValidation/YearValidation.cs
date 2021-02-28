using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using static System.Char;
using static System.String;

namespace CarPriceDesktop.Validations.CarModelValidation
{
    internal sealed class YearValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var maybeYear = value as string;

            return maybeYear switch
            {
                string when IsNullOrWhiteSpace(maybeYear) => new(false, "The value in the field cannot be empty"),
                string when maybeYear.Length != 4 => new(false, "4 characters are required"),
                string when !maybeYear.All(c => IsDigit(c)) => new(false, "Incorrect Characters"),
                _ => new(true, null)
            };
        }
    }
}
