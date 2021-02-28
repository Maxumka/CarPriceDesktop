using System.Globalization;
using System.Windows.Controls;

namespace CarPriceDesktop.Validations.CarModelValidation
{
    internal sealed class MileageEnginePowerValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!int.TryParse(value as string, out var maybeMileageOrEnginePower)) return new(false, "The value in the field must be a number");

            if (maybeMileageOrEnginePower < 0) return new(false, "The value in the field must be a positive number");

            return new(true, null);
        }
    }
}
