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
                                // Validate word length to ensure it's a reasonable value
                                if (length < 2)
                                {
                                    Console.WriteLine("Error: Word length must be at least 2.");
                                    return; // Exit the program
                                }
                                wordCount = length; // Set word count based on user input
                            }
                            else
                            {
                                Console.WriteLine("Error: Invalid word length. Please provide a valid integer.");
                                return; // Exit the program
                            }
                            break;
                        case "--vowel-replacement":
                            if (i + 1 < args.Length && bool.TryParse(args[++i], out bool replacement))
                            {
                                vowelReplacement = replacement; // Set vowel replacement based on user input
                            }
                            break;
                        default:
                            Console.WriteLine($"Error: Unknown argument '{args[i]}'.");
                            return; // Exit the program
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
                // After parsing command-line arguments
                Console.WriteLine("Do you want to add a custom word to your passphrase? (yes/no)");
                string customWordResponse = Console.ReadLine()?.ToLower();

                string? customWord = null; // Change to nullable
                if (customWordResponse == "yes" || customWordResponse == "sí")
                {
                    Console.WriteLine("Please enter your custom word:");
                    customWord = Console.ReadLine(); // This can be null if the user just presses Enter
                    wordCount++; // Increment word count to include the custom word
                }

                // Create an instance of PassphraseGenerator and generate a passphrase
                PassphraseGenerator generator = new PassphraseGenerator(language);
                string passphrase = generator.GeneratePassphrase(wordCount, vowelReplacement, customWord);

                // Output messages in the requested language
                string generatedMessage = language == "es" ? "Frase de contraseña generada: " : "Generated Passphrase: ";
                Console.ForegroundColor = ConsoleColor.Blue; // Set color for the generated message
                Console.WriteLine(generatedMessage); // Print the generated message
                Console.ForegroundColor = ConsoleColor.Green; // Set color for the passphrase
                Console.WriteLine(passphrase); // Print the generated passphrase
                Console.ResetColor(); // Reset to default color
            }
            catch (FileNotFoundException ex)
            {
                // Print error message if the wordlist file is not found
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Print error message for any other exceptions
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
