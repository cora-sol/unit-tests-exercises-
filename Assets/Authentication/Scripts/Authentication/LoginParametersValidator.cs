using System.Text.RegularExpressions;

namespace Authentication
{
    public class LoginParametersValidator
    {
        private const int MinimumNameCharacters = 4;
        private const int MaximumNameCharacters = 32;
        private const int MinimumPasswordCharacters = 8;
        private const int MaximumPasswordCharacters = 16;

        public bool AreValidParameters(string firstName, string lastName, string email, string password)
        {
            bool isValidFirstName = IsValidName(firstName);
            if (!isValidFirstName)
                return false;
            bool isValidLastName = IsValidName(lastName);
            if (!isValidLastName)
                return false;
            bool areValidEmailAndPassword = AreValidEmailAndPassword(email, password);
            if (!areValidEmailAndPassword)
                return false;
            return true;
        }

        public bool AreValidEmailAndPassword(string email, string password)
        {
            bool isValidPassword = IsValidPassword(password);
            if (!isValidPassword)
                return false;
            bool isValidEmail = IsValidEmail(email);
            if (!isValidEmail)
                return false;
            return true;
        }

        private bool IsValidName(string name)
        {
            name = name.Trim();
            int nameLength = name.Length;
            if (nameLength < MinimumNameCharacters)
                return false;
            if (nameLength > MaximumNameCharacters)
                return false;
            return true;
        }

        private bool IsValidPassword(string password)
        {
            password = password.Trim();
            int passwordLength = password.Length;
            if (passwordLength < MinimumPasswordCharacters)
                return false;
            if (passwordLength > MaximumPasswordCharacters)
                return false;
            return true;
        }

        private static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
        }
    }
}