using System;

namespace PassphraseGeneratorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set default values
            string language = "en"; // Default language
            int wordCount = 2; // Default minimum word length
            bool vowelReplacement = false; // Default vowel replacement

            // Check for command-line arguments
            if (args.Length > 0)
            {
                // Parse command-line arguments
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
                                vowelReplacement = replacement;
                            }
                            break;
                    }
                }
            }

            // Boxed title
            string appName = "Passphrase Generator";
            int boxWidth = Math.Max(appName.Length + 4, 60); // Minimum width of 60 characters
            Console.ForegroundColor = ConsoleColor.Blue; // Set color for the title box
            Console.WriteLine("┌" + new string('─', boxWidth) + "┐");
            // Center the title correctly
            int padding = (boxWidth - appName.Length - 2) / 2; // Calculate padding for centering
            Console.WriteLine("│" + new string(' ', padding) + appName + new string(' ', boxWidth - appName.Length - padding - 2) + "│");
            Console.WriteLine("└" + new string('─', boxWidth) + "┘");
            Console.ResetColor(); // Reset color for subsequent output

            try
            {
                PassphraseGenerator generator = new PassphraseGenerator(language);
                string passphrase = generator.GeneratePassphrase(wordCount, vowelReplacement);

                // Output messages in the requested language
                string generatedMessage = language == "es" ? "Frase de paso generada: " : "Generated Passphrase: ";
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(generatedMessage);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(passphrase);
                Console.ResetColor(); // Reset to default color
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
