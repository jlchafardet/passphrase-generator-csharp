using System;

namespace PassphraseGeneratorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: dotnet run --language <en|es> --word-length <number> --vowel-replacement <true|false>");
                return;
            }

            string language = args[1];
            int wordCount = int.Parse(args[3]);
            bool vowelReplacement = bool.Parse(args[5]);

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
