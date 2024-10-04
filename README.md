# Passphrase Generator

A console app for generating strong and unique passphrases.

## Features

- Generate passphrases using wordlists (English and Spanish)
- Accept arguments for language, word length, and vowel replacement
- Meet minimum and maximum length requirements (12-128 characters, 2-15 words)
- Randomly swap cases (uppercase) at least half of the letters on each word
- Handle errors and exceptions
- Update the README.md file to document new features or changes made to the codebase
- Use strikethroughs to mark as completed any tasks, features, or subfeatures

## Installation

1. Clone the repository: `git clone https://github.com/your-username/passphrase-generator.git`
2. Navigate to the project directory: `cd passphrase-generator`
3. Build and run the project: `dotnet run`

## Usage

To generate a passphrase, run the project with the desired arguments:

```bash
dotnet run --language en --word-length 5 --vowel-replacement true
```

### To-Do and phase deffinition

**Passphrase Generator Features**
=====================================

**MVP (Minimum Viable Product)**
-----------------------------

- Generate passphrases using wordlists (English and Spanish)
- Accept arguments for language, word length, and vowel replacement
- Meet minimum and maximum length requirements (12-128 characters, 2-15 words)
- Randomly swap cases (uppercase) at least half of the letters on each word
- Handle errors and exceptions

**Phase 1 (Easy-Moderate)**
-------------------------

- Add support for more languages (e.g., French, German, Italian)
- Implement a feature to generate passphrases with a specific theme (e.g., animals, countries, foods)
- Allow users to specify a custom wordlist file
- Add a feature to generate passphrases with a specific number of syllables
- Improve performance by optimizing wordlist loading and passphrase generation

**Phase 2 (Moderate-Hard)**
-------------------------

- Implement a feature to generate passphrases with a specific pattern (e.g., alternating uppercase and lowercase letters)
- Add support for generating passphrases with a specific character set (e.g., only alphanumeric characters)
- Implement a feature to generate passphrases with a specific entropy level (e.g., using a password strength estimator)
- Allow users to specify a custom character set for vowel replacement
- Improve error handling and exception handling

**Phase 3 (Hard)**
-----------------

- Implement a feature to generate passphrases using a machine learning model (e.g., a neural network)
- Add support for generating passphrases with a specific linguistic structure (e.g., using a grammar-based approach)
- Implement a feature to generate passphrases with a specific semantic meaning (e.g., using a knowledge graph)
- Allow users to specify a custom machine learning model for passphrase generation
- Improve performance by optimizing machine learning model loading and passphrase generation

**Future Features (Graphic User Interface)**
------------------------------------------

- Implement a graphic user interface (GUI) for the passphrase generator
- Allow users to interact with the passphrase generator using a GUI
- Implement features such as passphrase history, favorites, and password analysis

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.
