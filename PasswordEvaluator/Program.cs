namespace PasswordEvaluator

{
    using System.Text.RegularExpressions;
    using System.Text.RegularExpressions;

    /// <summary>
    ///  The user will enter a password and the program will evaluate the strength of the password 
    ///  based on the following guidelines: lowercase letters, uppercase letters, numbers, symbols, and length.
    /// </summary>
    class PasswordStrengthChecker
    {
        private string password; // the password that the user enters
        private double strength; // the strength of the password

        /// <summary>
        /// Initializes a new instance of the PasswordStrengthChecker class.
        /// </summary>
        /// <param name="password">The password entered by the user to be evaluated.</param>
        public PasswordStrengthChecker(string password)
        {
            this.password = password;
        }


        /// <summary>
        /// Determines the length of the password, if its equal or greater than 8 characters, it increases the strength
        /// </summary>
        private void PasswordLength()
        {
            if (password.Length >= 8)
                strength++;
        }

        /// <summary>
        /// checks if the password contains lowercase letters, if it does, it increases the strength
        /// </summary>
        private void PasswordLowercase()
        {
            if (Regex.IsMatch(password, @"[a-z]"))
                strength++;
        }

        /// <summary>
        /// if the password contains any uppercase letters, if it does, it increases the strength
        /// </summary>
        private void PasswordUppercase()
        {
            if (Regex.IsMatch(password, @"[A-Z]"))
                strength++;
        }

        /// <summary>
        /// checks if the password has any numbers, if it does, it increases the strength
        /// </summary>
        private void PasswordNumbers()
        {
            if (Regex.IsMatch(password, @"[0-9]"))
                strength++;
        }

        /// <summary>
        /// checks if the password has any symbols, if it does, it increases the strength
        /// </summary>
        private void PasswordSymbols()
        {
            if (Regex.IsMatch(password, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"))
                strength++;
        }


        /// <summary>
        /// Outputs the password's strength based on the strength value gained from the guidelines
        /// </summary>
        private void strengthEvaluation()
        {
            if (strength == 5)
                Console.WriteLine("Your password'a strength level is strong");
            else if (strength < 5 && strength >= 3)
                Console.WriteLine("Your password'a strength level is medium");
            else
                Console.WriteLine("Your password'a strength level is weak");
        }

        /// <summary>
        /// determines the strength of the user's password by applying the previous methods(guidelines).
        /// </summary>
        public void CheckPasswordStrength()
        {
            PasswordLength();
            PasswordLowercase();
            PasswordUppercase();
            PasswordNumbers();
            PasswordSymbols();
            strengthEvaluation();
        }
    }


    class PasswordEvaluatorApp
    {
        static void Main(string[] args)
        {
            string password; // the password that the user enters
            PasswordStrengthChecker passwordStrengthChecker;

            PromptForPassword(out password, out passwordStrengthChecker);

            Console.WriteLine("Would you like to enter another password? (yes/no)");
            string answer = Console.ReadLine();

            while (answer.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                PromptForPassword(out password, out passwordStrengthChecker);
                Console.WriteLine("Would you like to enter another password? (yes/no)");
                answer = Console.ReadLine();
            }

            if (answer.Equals("no", StringComparison.OrdinalIgnoreCase))

                Console.WriteLine("Have a nice day!");
        }

        /// <summary>
        /// Prompts the user to enter a password, initializes the PasswordStrengthChecker, and evaluates password strength.
        /// </summary>
        /// <param name="password">The user-entered password.</param>
        /// <param name="passwordStrengthChecker">Instance of PasswordStrengthChecker to analyze the password.</param>
        private static void PromptForPassword(out string password, out PasswordStrengthChecker passwordStrengthChecker)
        {
            Console.WriteLine("Welcome! Please enter a password:");
            password = Console.ReadLine();
            passwordStrengthChecker = new PasswordStrengthChecker(password);
            passwordStrengthChecker.CheckPasswordStrength();
        }
    }
}