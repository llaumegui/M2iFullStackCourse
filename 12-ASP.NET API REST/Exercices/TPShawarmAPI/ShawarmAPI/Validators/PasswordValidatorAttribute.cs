using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ShawarmAPI.Validators;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class PasswordValidatorAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        string? input = value?.ToString();
        ErrorMessage = string.Empty;

        if(string.IsNullOrWhiteSpace(input))
            ErrorMessage = "Password should not be empty. ";
        else
        {
            var hasEnoughChars = new Regex(@".{8,}");
            var hasNumbers = new Regex(@"[0-9]");
            var hasUpperLetters = new Regex(@"[A-Z]");
            var hasLowerLetters = new Regex(@"[a-z]");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasEnoughChars.IsMatch(input))
                ErrorMessage += "Password should not be less than 8 characters. ";
            if (hasLowerLetters.Matches(input).Count < 1)
                ErrorMessage += "Password should contain at least 1 lower case letter. ";
            if (hasUpperLetters.Matches(input).Count < 1)
                ErrorMessage += "Password should contain at least 1 upper case letter. ";
            if (hasNumbers.Matches(input).Count < 1)
                ErrorMessage += "Password should contain at least 1 numeric character. ";
            if (hasSymbols.Matches(input).Count < 1)
                ErrorMessage += "Password should contain at least 1 special character. ";

            if (ErrorMessage == string.Empty)
                return true;
        }
        return false;
    }
}