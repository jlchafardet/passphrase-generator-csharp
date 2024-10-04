using System;

namespace PassphraseGeneratorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set default values for language, word count, and vowel replacement
            string language = "en"; // Default language is English
            int wordCount = 2; // Default minimum word length is 2
            bool vowelReplacement = false; // Default vowel replacement is disabled

            // Check for command-line arguments
            if (args.Length > 0)
            {
                // Parse command-line arguments to override default values
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "--language":
                            if (i + 1 < args.Length)
                            {
                                language = args[++i]; // Set language to the first parameter received
                            }
                            break;
                        case "--word-length":
                            if (i + 1 < args.Length && int.TryParse(args[++i], out int length))
                            {
                                wordCount = Math.Max(length, 2); // Ensure minimum word length is 2
                            }
                            break;
                        case "--vowel-replacement":
                            if (i + 1 < args.Length && bool.TryParse(args[++i], out bool replacement))
                            {
                                vowelReplacement = replacement; // Set vowel replacement based on user input
                            }
                            break;
                    }
                }
            }

            // Boxed title
            string appName = "Passphrase Generator"; // Application name
            int boxWidth = Math.Max(appName.Length + 4, 60); // Minimum width of 60 characters
            Console.ForegroundColor = ConsoleColor.Blue; // Set color for the title box
            Console.WriteLine("┌" + new string('─', boxWidth) + "┐"); // Print top border of the box
            // Center the title correctly
            int padding = (boxWidth - appName.Length - 2) / 2; // Calculate padding for centering
            Console.WriteLine("│" + new string(' ', padding) + appName + new string(' ', boxWidth - appName.Length - padding) + "│"); // Print the title
            Console.WriteLine("└" + new string('─', boxWidth) + "┘"); // Print bottom border of the box
            Console.ResetColor(); // Reset color for subsequent output

            try
            {
                // Create an instance of PassphraseGenerator and generate a passphrase
                PassphraseGenerator generator = new PassphraseGenerator(language);
                string passphrase = generator.GeneratePassphrase(wordCount, vowelReplacement);

                // Output messages in the requested language
                string generatedMessage = language == "es" ? "Frase de contraseña generada: " : "Generated Passphrase: ";
                Console.ForegroundColor = ConsoleColor.Blue; // Set color for the generated message
                Console.WriteLine(generatedMessage); // Print the generated message
                Console.ForegroundColor = ConsoleColor.Green; // Set color for the passphrase
                Console.WriteLine(passphrase); // Print the generated passphrase
                Console.ResetColor(); // Reset to default color
            }
            catch (Exception ex)
            {
                // Print error message if an exception occurs
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
