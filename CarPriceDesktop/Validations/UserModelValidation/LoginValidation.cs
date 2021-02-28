using System.Linq;
using System.Globalization;
using System.Windows.Controls;
using static System.String;
using static System.Char;

namespace CarPriceDesktop.Validations.UserModelValidation
{
    internal sealed class LoginValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var maybeLogin = value as string;

            return maybeLogin switch
            {
                string when IsNullOrWhiteSpace(maybeLogin) => new(false, "The value in the field cannot be empty"),
                string when maybeLogin.Length < 4 => new(false, "Minimum length 4 characters"),
                string when !maybeLogin.All(c => IsLetterOrDigit(c)) => new(false, "Incorrect Characters"),
                string when !IsLetter(maybeLogin.First()) => new(false, "The first character must be a letter."),
                _ => new(true, null)
            };
        }
    }
}
