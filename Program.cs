using System;

namespace PassphraseGeneratorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check for the -help argument
            if (args.Length > 0 && args[0] == "-help")
            {
                DisplayHelp();
                return; // Exit the application after displaying help
            }

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
                                language = args[i + 1] ?? "en"; // Use null-coalescing operator
                                i++; // Skip the next argument
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
                string customWordPrompt = language == "es" 
                    ? "¿Quieres agregar una palabra personalizada a tu frase de contraseña? (sí/no)" 
                    : "Do you want to add a custom word to your passphrase? (yes/no)";
                
                Console.WriteLine(customWordPrompt);
                string customWordResponse = Console.ReadLine()?.ToLower();

                string customWord = string.Empty; // Initialize as an empty string
                if (customWordResponse == "yes" || customWordResponse == "sí")
                {
                    Console.WriteLine(language == "es" ? "Por favor, ingresa tu palabra personalizada:" : "Please enter your custom word:");
                    string? customWordInput = Console.ReadLine(); // Read input separately
                    if (!string.IsNullOrEmpty(customWordInput))
                    {
                        customWord = customWordInput; // Assign only if not null or empty
                    }
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

        // Method to display help information
        static void DisplayHelp()
        {
            Console.WriteLine("Usage: dotnet run [options]");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White; // Set color for the main text
            Console.WriteLine("Options:");

            Console.ForegroundColor = ConsoleColor.Green; // Set color for options
            Console.WriteLine("  --language <lang>                  Set the language for the passphrase (default: en)");
            Console.WriteLine("  --word-length <length>             Set the number of words in the passphrase (default: 2, range: 2-15)");
            Console.WriteLine("  --vowel-replacement <true|false>   Enable or disable vowel replacement (default: false)");
            Console.WriteLine("  -help                              Display this help message.");

            Console.ForegroundColor = ConsoleColor.White; // Reset color for the rest of the text
            Console.WriteLine();
            Console.WriteLine("If no arguments are provided, the application defaults to generating a passphrase with 2 words in English.");

            // Reset color to default
            Console.ResetColor();
        }
    }
}