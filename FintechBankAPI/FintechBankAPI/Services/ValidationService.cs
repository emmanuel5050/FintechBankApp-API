using FintechBankAPI.DTOs;
using FintechBankAPI.Interfaces;
using System.Text.RegularExpressions;

namespace FintechBankAPI.Services
{
    public class ValidationService : IValidationService
    {
        private const string NINRegex = @"^[0-9]{11}$";
        private const string EmailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        private const string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$@!%&*?])[A-Za-z\d#$@!%&*?]{8,50}$"; 

        public IDictionary<string, string> ValidateCustomer(RegisterDTO registerDTO)
        {
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(registerDTO.NinNo)
                || !Regex.IsMatch(registerDTO.NinNo, NINRegex, RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(200)))
            {
                errors.Add("NINnumber", "Please enter a valid NIN");
            }
            if (string.IsNullOrEmpty(registerDTO.FirstName) || registerDTO.FirstName.Length > 20)
            {
                errors.Add("FirstName", "Please enter first name. Not more than 20 characters");
            }
            if (string.IsNullOrEmpty(registerDTO.LastName) || registerDTO.LastName.Length > 20)
            {
                errors.Add("LastName", "Please enter last name. Not more than 20 characters");
            }
            if ((DateTime.Now.Year - registerDTO.Dob.Year) < 18)
            {
                errors.Add("DateOfBirth", "Please enter a valid date of birth. Customer must be 18+");
            }
            if (string.IsNullOrEmpty(registerDTO.Email)
              || !Regex.IsMatch(registerDTO.Email, EmailRegex, RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(200)))
            {
                errors.Add("EmailAddress", "Please enter a valid email address");
            }

            if (string.IsNullOrEmpty(registerDTO.UserName) || registerDTO.UserName.Length > 30)
            {
                errors.Add("Username", "Please enter username. Not more than 30 characters");
            }
            if (string.IsNullOrEmpty(registerDTO.Password)
                || !Regex.IsMatch(registerDTO.Password, PasswordRegex, RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(200)))
            {
                errors.Add("Password", "Please enter a passwsord. More than 8 characters, less than 50, lowercase, uppercase, numeric, symbol");
            }
            return errors;

        }
    }
}
