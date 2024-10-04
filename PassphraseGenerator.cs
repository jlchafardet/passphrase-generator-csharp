using System;
using System.Collections.Generic;
using System.IO;

namespace PassphraseGeneratorApp
{
    public class PassphraseGenerator
    {
        private List<string> wordList = new List<string>(); // Initialize to an empty list

        public PassphraseGenerator(string language)
        {
            LoadWordList(language);
        }

        private void LoadWordList(string language)
        {
            string filePath = $"wordlists/words-{language}.txt";
            if (File.Exists(filePath))
            {
                wordList = new List<string>(File.ReadAllLines(filePath));
            }
            else
            {
                throw new FileNotFoundException($"Wordlist for language '{language}' not found.");
            }
        }

        public string GeneratePassphrase(int wordCount, bool vowelReplacement)
        {
            Random random = new Random();
            List<string> selectedWords = new List<string>();

            for (int i = 0; i < wordCount; i++)
            {
                int index = random.Next(wordList.Count);
                string word = wordList[index];

                if (vowelReplacement)
                {
                    word = ReplaceVowels(word); // Call the ReplaceVowels method
                }

                selectedWords.Add(RandomCaseSwap(word));
            }

            return string.Join(" ", selectedWords);
        }

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

            char[] characters = word.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                if (vowelMapping.ContainsKey(characters[i]))
                {
                    characters[i] = vowelMapping[characters[i]]; // Replace vowel with mapped character
                }
            }
            return new string(characters);
        }

        private string RandomCaseSwap(string word)
        {
            char[] characters = word.ToCharArray();
            Random random = new Random();
            for (int i = 0; i < characters.Length; i++)
            {
                if (random.Next(2) == 0) // 50% chance to swap case
                {
                    characters[i] = char.IsUpper(characters[i]) ? char.ToLower(characters[i]) : char.ToUpper(characters[i]);
                }
            }
            return new string(characters);
        }
    }
}
