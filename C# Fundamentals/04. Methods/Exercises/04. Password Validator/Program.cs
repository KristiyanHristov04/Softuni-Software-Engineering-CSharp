using System;

namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            int numberOfChars = NumberOfCharacters(password);
            int numberOfDigits = NumberOfDigits(password);
            bool wrongSymbols = ContainsWrongSymbols(password);
            bool isValid = true;
            if (numberOfChars < 6 || numberOfChars > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }
            if (!wrongSymbols)
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }
            if (numberOfDigits < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid=false;
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }
        static int NumberOfCharacters(string password)
        {
            int numberOfChars = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if ((password[i] >= 'A' && password[i] <= 'Z') || (password[i] >= 'a' && password[i] <= 'z') || (password[i] >= 32 && password[i] <= 127))
                {
                    numberOfChars++;
                }
            }
            return numberOfChars;
        }

        static int NumberOfDigits(string password)
        {
            int numberOfDigits = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (Convert.ToInt32(password[i] - '0') >= 0 && Convert.ToInt32(password[i] - '0') <= 9)
                {
                    numberOfDigits++;
                }
            }
            return numberOfDigits;
        }

        static bool ContainsWrongSymbols(string password)
        {
            bool wrongSymbols = true;
            for (int i = 0; i < password.Length; i++)
            {
                if ((password[i] >= 0 && password[i] <= 47) || (password[i] >= 58 && password[i] <= 64) 
                    || (password[i] >= 91 && password[i] <= 96) 
                    || (password[i] >= 123 && password[i] <= 127))
                {
                    wrongSymbols = false;
                }
            }
            return wrongSymbols;
        }

    }
}
