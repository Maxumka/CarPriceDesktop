using System.Linq;
using System.Globalization;
using System.Windows.Controls;
using static System.String;
using static System.Char;

namespace CarPriceDesktop.Validations.UserModelValidation
{
    internal sealed class PasswordValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var maybePassword = value as string;

            return maybePassword switch
            {
                string when IsNullOrWhiteSpace(maybePassword) => new(false, "The value in the field cannot be empty"),
                string when maybePassword.Length < 6 => new(false, "Minimum length 6 characters"),
                string when !maybePassword.All(c => IsLetterOrDigit(c)) => new(false, "Incorrect Characters"),
                _ => new(true, null)
            };
        }
    }
}
