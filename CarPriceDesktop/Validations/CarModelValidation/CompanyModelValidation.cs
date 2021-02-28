using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using static System.String;

namespace CarPriceDesktop.Validations.CarModelValidation
{
    internal sealed class CompanyModelValidation : ValidationRule
    {
        private static bool IsSpaceOrLatinOrDigit(char c) => c is ' ' or >= 'a' and <= 'z' or >= '0' and <= '9';

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var maybeCompanyModel = value as string;

            return maybeCompanyModel switch
            {
                string when IsNullOrWhiteSpace(maybeCompanyModel) => new(false, "The value in the field cannot be empty"),
                string when maybeCompanyModel.Length <= 2 => new(false, "Minimum length 3 characters"),
                string when !maybeCompanyModel.All(c => IsSpaceOrLatinOrDigit(c)) => new(false, "Incorrect Characters"),
                _ => new(true, null)
            };
        }
    }
}
