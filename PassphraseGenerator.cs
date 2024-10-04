using System;
using System.Collections.Generic;
using System.IO;

namespace PassphraseGeneratorApp
{
    public class PassphraseGenerator
    {
        private List<string> wordList = new List<string>(); // List to hold words from the loaded wordlist

        // Constructor that initializes the PassphraseGenerator with the specified language
        public PassphraseGenerator(string language)
        {
            LoadWordList(language); // Load the appropriate wordlist based on the language
        }

        // Loads the wordlist from a file based on the specified language
        private void LoadWordList(string language)
        {
            string filePath = $"wordlists/words-{language}.txt"; // Construct the file path for the wordlist
            if (File.Exists(filePath))
            {
                wordList = new List<string>(File.ReadAllLines(filePath)); // Read all lines from the file into the wordList
                if (wordList.Count == 0)
                {
                    throw new InvalidOperationException($"The wordlist for language '{language}' is empty."); // Check if the wordlist is empty
                }
            }
            else
            {
                throw new FileNotFoundException($"Wordlist for language '{language}' not found."); // Throw an error if the file does not exist
            }
        }

        // Generates a passphrase consisting of a specified number of words, with optional vowel replacement
        public string GeneratePassphrase(int wordCount, bool vowelReplacement, string? customWord = null) // Change to string?
        {
            // Validate maximum word count
            if (wordCount < 2 || wordCount > 15)
            {
                throw new ArgumentOutOfRangeException(nameof(wordCount), "Word count must be between 2 and 15.");
            }

            if (wordCount > wordList.Count + (customWord != null ? 1 : 0))
            {
                throw new ArgumentOutOfRangeException(nameof(wordCount), $"Requested word count {wordCount} exceeds available words in the list."); // Validate word count
            }

            Random random = new Random(); // Random number generator
            List<string> selectedWords = new List<string>(); // List to hold the selected words for the passphrase

            // Include custom word if provided
            if (!string.IsNullOrEmpty(customWord))
            {
                selectedWords.Add(customWord);
            }

            int maxVowelReplacementCount = wordCount / 2; // Calculate max words for vowel replacement
            int vowelReplacedCount = 0; // Counter for words with vowel replacement

            for (int i = selectedWords.Count; i < wordCount; i++)
            {
                int index = random.Next(wordList.Count); // Select a random index from the wordList
                string word = wordList[index]; // Get the word at the selected index

                // Apply vowel replacement only if the limit has not been reached
                if (vowelReplacement && vowelReplacedCount < maxVowelReplacementCount)
                {
                    word = ReplaceVowels(word); // Replace vowels in the word if specified
                    vowelReplacedCount++; // Increment the count of replaced words
                }

                selectedWords.Add(RandomCaseSwap(word)); // Add the word (with case swapped) to the selectedWords list
            }

            string passphrase = string.Join(" ", selectedWords); // Join the selected words into a single passphrase string

            // Validate maximum character length
            if (passphrase.Length > 128)
            {
                throw new InvalidOperationException("Generated passphrase exceeds the maximum length of 128 characters.");
            }

            return passphrase; // Return the generated passphrase
        }

        // Replaces vowels in the given word according to a predefined mapping
        private string ReplaceVowels(string word)
        {
            // Define a mapping for vowel replacement, excluding 'u'
            var vowelMapping = new Dictionary<char, char>
            {
                { 'a', '@' },
                { 'e', '3' },
                { 'i', '!' },
                { 'o', '0' },
                { 'A', '@' },
                { 'E', '3' },
                { 'I', '!' },
                { 'O', '0' }
                // 'u' and 'U' are not included in the mapping
            };

            char[] characters = word.ToCharArray(); // Convert the word to a character array
            for (int i = 0; i < characters.Length; i++)
            {
                if (vowelMapping.ContainsKey(characters[i]))
                {
                    characters[i] = vowelMapping[characters[i]]; // Replace vowel with mapped character
                }
            }
            return new string(characters); // Return the modified word as a string
        }

        // Randomly swaps the case of characters in the given word
        private string RandomCaseSwap(string word)
        {
            char[] characters = word.ToCharArray(); // Convert the word to a character array
            Random random = new Random(); // Random number generator
            for (int i = 0; i < characters.Length; i++)
            {
                if (random.Next(2) == 0) // 50% chance to swap case
                {
                    characters[i] = char.IsUpper(characters[i]) ? char.ToLower(characters[i]) : char.ToUpper(characters[i]);
                }
            }
            return new string(characters); // Return the modified word as a string
        }
    }
}
