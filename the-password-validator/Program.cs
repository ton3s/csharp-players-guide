namespace the_password_validator;
class Program
{
    static void Main(string[] args)
    {
        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The Password Validator");

        while (true)
        {
            Console.Write("Please enter a password to validate: ");
            string input =  Console.ReadLine() ?? "";
            if (IsValidPassword(input)) {
                Console.WriteLine($"{input} is a valid password.");
            }
            else
            {
                Console.WriteLine($"{input} is a not valid password.");
            }
        }

        bool IsValidPassword(string password)
        {
            bool isValid = true;
            bool containsUpper = false;
            bool containsLower = false;
            bool containsNumber = false;
            bool containsUppercaseT = false;
            bool containsAmbersand = false;

            // Length
            if (password.Length < 6 || password.Length > 13)
            {
                Console.WriteLine($"Password needs to be between 6-13 characters.");
                isValid = false;
            }

            // Check characters
            foreach (char letter in password) {
                if (char.IsUpper(letter)) containsUpper = true;
                if (char.IsLower(letter)) containsLower = true;
                if (char.IsNumber(letter)) containsNumber = true;
                if (letter == 'T') containsUppercaseT = true;
                if (letter == '&') containsAmbersand = true;
            }

            if (!(containsUpper && containsLower && containsNumber))
            {
                if (!containsUpper) Console.WriteLine($"Missing at least 1 uppercase letter.");
                if (!containsLower) Console.WriteLine($"Missing at least 1 lowercase letter.");
                if (!containsNumber) Console.WriteLine($"Missing at least 1 number.");
                isValid = false;
            }

            if (containsUppercaseT)
            {
                Console.WriteLine("Cannot contain a capital T.");
                isValid = false;
            }

            if (containsAmbersand)
            {
                Console.WriteLine("Cannot contain a ambersand (&).");
                isValid = false;
            }

            return isValid;
        }
    }
}
