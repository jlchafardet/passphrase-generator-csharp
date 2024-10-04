﻿using System;

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

            try
            {
                PassphraseGenerator generator = new PassphraseGenerator(language);
                string passphrase = generator.GeneratePassphrase(wordCount, vowelReplacement);
                Console.WriteLine($"Generated Passphrase: {passphrase}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
