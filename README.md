# Passphrase Generator

A console app for generating strong and unique passphrases.

![Passphrase Generator](https://i.imgur.com/L2Azhow.png)

## Features

- Generate passphrases using wordlists (English and Spanish)
- Accept arguments for language, word length, and vowel replacement
- Meet minimum and maximum length requirements (12-128 characters, 2-15 words)
- Randomly swap cases (uppercase) at least half of the letters on each word
- Allow users to add a custom word to their passphrase
- Display help information with the `-help` argument
- Handle errors and exceptions

## Installation

1. Clone the repository: `git clone https://github.com/jlchafardet/passphrase-generator-csharp.git`
2. Navigate to the project directory: `cd passphrase-generator`
3. Build and run the project: `dotnet run`

## Usage

To generate a passphrase, run the project with the desired arguments:

```bash
dotnet run --language en --word-length 5 --vowel-replacement true
```

### To-Do and phase definition

**Passphrase Generator Features**
=====================================

**MVP (Minimum Viable Product)**
-----------------------------

- ~~Generate passphrases using wordlists (English and Spanish)~~
- ~~Accept arguments for language, word length, and vowel replacement~~
- ~~Meet minimum and maximum length requirements (12-128 characters, 2-15 words)~~
- ~~Randomly swap cases (uppercase) at least half of the letters on each word~~
- ~~Handle errors and exceptions~~

**Phase 1 (Easy-Moderate)**
-------------------------

- Add support for more languages (e.g., French, German, Italian)
- Implement a feature to generate passphrases with a specific theme (e.g., animals, countries, foods)
- Allow users to specify a custom wordlist file
- Add a feature to generate passphrases with a specific number of syllables
- ~~Improve performance by optimizing wordlist loading and passphrase generation~~
- ~~Allow users to add a custom word to their passphrase~~  <!-- New feature added -->
- ~~Implement -help argument to display usage information~~  <!-- New feature added -->

**Phase 2 (Moderate-Hard)**
-------------------------

- Implement a feature to generate passphrases with a specific pattern (e.g., alternating uppercase and lowercase letters)
- Add support for generating passphrases with a specific character set (e.g., only alphanumeric characters)
- Implement a feature to generate passphrases with a specific entropy level (e.g., using a password strength estimator)
- Allow users to specify a custom character set for vowel replacement
- Improve error handling and exception handling

**Phase 3 (Hard)**
-----------------

- **Implement a feature to generate passphrases with a specific linguistic structure**:
  - Define what constitutes a linguistic structure (e.g., noun-verb-noun).
  - Create a set of rules for generating passphrases based on these structures.
  - Implement a mechanism to select words that fit the defined structure.

- **Implement a feature to generate passphrases with a specific semantic meaning**:
  - Research and define what types of semantic meanings can be used (e.g., themes like "adventure" or "safety").
  - Create a mapping of words to their semantic categories.
  - Develop a method to generate passphrases that align with the chosen semantic meaning.

**Future Features (Graphic User Interface)**
------------------------------------------

- Implement a graphic user interface (GUI) for the passphrase generator
- Allow users to interact with the passphrase generator using a GUI
- Implement features such as passphrase history, favorites, and password analysis

**Future Features (Web-Based Version)**
----------------------------------------

- Implement a web-based version of the passphrase generator
- Allow users to access the passphrase generator through a web interface
- Include features such as:
  - User authentication to save favorite passphrases
  - A history of generated passphrases for easy access
  - Responsive design for mobile and desktop users

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.

## License

This project is licensed under the GNU General Public License (GPL) v3.0. See the [LICENSE](LICENSE) file for details.

## Author

José Luis Chafardet G.  
Email: jose.chafardet@icloud.com
