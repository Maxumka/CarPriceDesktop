using System.Globalization;
using System.Linq;
using static System.Char;
using System.Windows.Controls;

namespace CarPriceDesktop.Validations.CarModelValidation
{
    internal sealed class EngineVolumeValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var valueForParse = value as string;

            if (!string.IsNullOrEmpty(valueForParse) && !IsDouble(ref valueForParse)) return new(false, "The value in the field must be a number");

            return new(true, null);
        }

        private static bool IsDouble(ref string value)
        {
            var valueSplitDot = value.Split('.');

            if (valueSplitDot.Length != 2) return value.All(c => IsDigit(c));

            return valueSplitDot.First().All(c => IsDigit(c)) && valueSplitDot.Last().All(c => IsDigit(c));
        }
    }
}
