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
            }
            else
            {
                throw new FileNotFoundException($"Wordlist for language '{language}' not found."); // Throw an error if the file does not exist
            }
        }

        // Generates a passphrase consisting of a specified number of words, with optional vowel replacement
        public string GeneratePassphrase(int wordCount, bool vowelReplacement)
        {
            Random random = new Random(); // Random number generator
            List<string> selectedWords = new List<string>(); // List to hold the selected words for the passphrase

            for (int i = 0; i < wordCount; i++)
            {
                int index = random.Next(wordList.Count); // Select a random index from the wordList
                string word = wordList[index]; // Get the word at the selected index

                if (vowelReplacement)
                {
                    word = ReplaceVowels(word); // Replace vowels in the word if specified
                }

                selectedWords.Add(RandomCaseSwap(word)); // Add the word (with case swapped) to the selectedWords list
            }

            return string.Join(" ", selectedWords); // Join the selected words into a single passphrase string
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
