namespace Hangman_game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int EXTRA_TRIES = 3;
            List<string> listOfWords = new List<string> { "won", "lemon", "wait", "hot", "shop", "nut", "peanut", "owowomomo" };
            Random random = new Random();
            string theRandomWordToGuess = listOfWords[random.Next(listOfWords.Count)];
            string[] emptyStringArray = new string[theRandomWordToGuess.Length];

            int emptyStringIteration = 0;
            for (int i = emptyStringIteration; i < emptyStringArray.Length; i++)
            {
                emptyStringArray[i] = "_"; // add _ to each index
            }

            int totalAttempts = theRandomWordToGuess.Length + EXTRA_TRIES;
            List<char> guessedLetters = new List<char>(); // Track guessed letters
            Console.Clear();  // Clear the console to create a fresh screen for each attempt
            Console.WriteLine("This is a Hangman game to guess a random word!");
            Console.Write($"Guess this {theRandomWordToGuess.Length} character word: ");

            foreach (string letter in emptyStringArray)// show current state of the word being guessed
            {
                Console.Write(letter + " "); //show gussed & ungussed letters
            }
            Console.WriteLine($"\nYou have {totalAttempts} tries.\n");
            int startAttempt = 1;

            for (int j = startAttempt; j <= totalAttempts; j++)
            {
                Console.Write($"Attempt #{j}: Enter 1 character: ");
                string userInput = Console.ReadLine().ToLower();


                if (userInput.Length != 1 || (userInput[0] < 'a' || userInput[0] > 'z')) // checks if userinput is a 1 char btw a-z
                {
                    Console.WriteLine("Invalid input! Please enter exactly one letter (a-z).");
                    j--; // Allow retry without counting the attempt
                    continue;
                }

                char guessedChar = userInput[0]; //convert userinput to char & store in 


                bool alreadyGuessed = false;
                foreach (char letter in guessedLetters) // Check if player already guessed the letter/character
                {
                    if (letter == guessedChar)
                    {
                        alreadyGuessed = true;
                        break;
                    }
                }

                if (alreadyGuessed)
                {
                    Console.WriteLine("Try again! you already got this letter.");
                    j--; // Allow retry without counting the attempt
                    continue;
                }

                guessedLetters.Add(guessedChar); // add guessed letter to the list

                bool correctGuess = false;
                for (int k = 0; k < theRandomWordToGuess.Length; k++)
                {
                    if (theRandomWordToGuess[k] == guessedChar) // check if guessed letter match the randomword
                    {
                        emptyStringArray[k] = guessedChar.ToString(); // replace _ with match letter at the correct index
                        correctGuess = true;
                    }
                }

                Console.Write("Word match: ");
                foreach (string letter in emptyStringArray) // Print updated word
                {
                    Console.Write(letter + " ");
                }
                Console.WriteLine();

                if (!correctGuess)
                {
                    Console.WriteLine("Wrong guess!");
                }
                bool completeWord = true;
                foreach (string letter in emptyStringArray) // Check if all characters have been guessed
                {
                    if (letter == "_")
                    {
                        completeWord = false;
                        break;
                    }
                }

                if (completeWord)
                {
                    Console.WriteLine($"Congratulations! You guessed the word: {theRandomWordToGuess}");
                    // return;
                    Console.ReadKey();  // Pause the game until the user presses a key

                }
            }
            Console.WriteLine($"You lose! The word was: {theRandomWordToGuess}");
        }
    }
}
