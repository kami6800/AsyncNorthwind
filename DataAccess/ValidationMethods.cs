using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    class ValidationMethods
    {
        static public bool ValidString(string value, int maxLength)
        {
            bool isValid = false;

            if (!string.IsNullOrWhiteSpace(value) && value.Length <= maxLength && value.Any(char.IsLetter))
            {
                isValid = true;
            }

            return isValid;
        }

        static public bool ValidDigits(string value, int maxLength)
        {
            bool isValid = false;

            if (!string.IsNullOrWhiteSpace(value) && value.Length <= maxLength && value.All(char.IsDigit))
                isValid = true;

            return isValid;
        }

        static public bool ValidInt(int value)
        {
            bool isValid = false;

            if (value > 0)
                isValid = true;

            return isValid;
        }
    }
}
