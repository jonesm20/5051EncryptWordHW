//Author: Melissa Jones
//CPSC 5051, April 29th, 2018
//Revision History: 1

using System.Reflection.Emit;

namespace EncryptWordHW2 {

    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    
    public class EncryptWord {
         const int Alphlebet = 26;
        const int Uppercase = 65;
        const int Lowercase = 97;
        readonly string _word;
        readonly int _shift;
        private string _encrypted;
        private int _queryCount;
        private int _highGuessHolder;
        private int _lowGuessHolder;
        private int _sumOfGuesses;
        private bool _isOn;
        
        
        //constructor with a given word and no given shift
        public  EncryptWord(string word)
        {
            _word = word;
            _isOn = false;
            _queryCount = 0;
            _highGuessHolder = 0;
            _lowGuessHolder = 0;
            _sumOfGuesses = 0;
            Random rnd = new Random();
            _shift = rnd.Next(1, 20);
            _encrypted = "";
        }
        
        //constructor with a given shift
        public EncryptWord(string word, int shift)
        {
            _word = word;
            _shift = shift;
            _isOn = false;
            _queryCount = 0;
            _highGuessHolder = 0;
            _lowGuessHolder = 0;
            _sumOfGuesses = 0;
            _encrypted = "";
        }
        
        //default constructor with no given parameters
        public EncryptWord()
        {
            _isOn = false;
            _queryCount = 0;
            _highGuessHolder = 0;
            _lowGuessHolder = 0;
            _sumOfGuesses = 0;
            Random rnd = new Random();
            _shift = rnd.Next(1, 20);
            _encrypted = "";
        }
        
        //Method to encrypt the given word after processing out
        //spaces and non-alpha characters
        public string EncryptOn()
        {
            _isOn = true;
            string pword = ProcessLine(_word);
            for (int i = 0; i < pword.Length; i++)
            {
                int newCharNum;
                char newChar;
                if (pword.Any(char.IsUpper))
                {
                     newCharNum = (pword.IndexOf(_word[i]) + _shift - Lowercase)
                                  % Alphlebet + Lowercase;
                     newChar = (char) newCharNum;
                     _encrypted += newChar;
                }
                else
                {
                    newCharNum = (pword.IndexOf(pword[i]) + _shift - Uppercase)
                                 % Alphlebet + Uppercase;
                    newChar = (char) newCharNum;
                    _encrypted += newChar;
                }
            }
            return _encrypted;
        }

        //Returns the encrypted word
        public string GetEncrypted()
        {
            return _encrypted;
        }
        
        //Gets the query count
        public int GetQueryCount() 
        {
            return _queryCount;
        }

        //Resets the counters to zero
        public void Reset()
        {
            _highGuessHolder = 0;
            _lowGuessHolder = 0;
            _sumOfGuesses = 0;
            _queryCount = 0;
            _isOn = false;
        }

        //Returns the 'decrypted' and processed word
        public string Decrypt()
        {
            _isOn = false;
            return ProcessLine(_word);
        }

        //A method to check the current state of the program
        public bool IsEncryptWordOn()
        {
            return _isOn;
        }
        
        //Processes out symbols and spaces from the original given work to 
        //ensure only alpha characters are being encrypted.
        private static string ProcessLine(string input)
        {
            string processedword = input.Trim();
            Regex rgx = new Regex("[^a-zA-Z]");
            processedword = rgx.Replace(processedword, "");
            return processedword;
        }
        
        //Checks someones guessed shift against the actual private shift
        public bool Guess(int guess)
        {
            if (guess == _shift)
            {
                _isOn = false;  //once the correct shift is guessed the 'game'
                               //is over and the word is uncrypted (turned off)
                return true;
            }
            GuessIncrement(guess);
            return false;
        }

        //Increments all the counters and trackers for the guessing part
        //of the game
        public void GuessIncrement(int guess)
        {
            if (guess != 0)
            {
                _queryCount++;
                HighestGuess(guess);
                LowestGuess(guess);
                _sumOfGuesses += guess;
            }
        }

        //Tracks the highest guess
        private void HighestGuess(int currentguess)
        {
            if (currentguess > _highGuessHolder)
            {
                _highGuessHolder = currentguess;
            }
        }

        //Tracks the lowest guess
        private void LowestGuess(int currentguess)
        {
            if (_lowGuessHolder == 0)
            {
                _lowGuessHolder = currentguess;
            }

            if (currentguess < _lowGuessHolder)
            {
                _lowGuessHolder = currentguess;
            }
        }

        //Getter function for the highest guess
        public int GetHighestGuess()
        {
            return _highGuessHolder;
        }

        //Getter function for the lowest guess
        public int GetLowestGuess()
        {
            return _lowGuessHolder;
        }

        //Calculates the average number guessed
        public int AverageGuess()
        {
            int average = 0;
            if (_queryCount != 0)
            {
                average = _sumOfGuesses / _queryCount;
            }
            return average;
        }

    }
}