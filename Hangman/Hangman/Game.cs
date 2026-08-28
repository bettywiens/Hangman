using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Forms;

namespace Hangman
{
    internal class Game
    {
        public static void StartGame(string word, string hint)
        {
            List<string> guessList = new List<string>();
            List<string> crypticWord = new List<string>();

            char[] letters = word.ToCharArray();

            string guessedLetter = "_";          
            int guessedLetterIndex = 0;
            int lettercount = word.Length;

            int mistakes = 0;


            for (int i = 0; i < lettercount; i++)
            {
                crypticWord.Add("_");
            }

            bool condition = true;


            Console.WriteLine("WILKOMMEN ZU HANGMAN");
            Console.WriteLine($"Hinweis zum Wort: {hint}");

            
            while (condition)
            {

                try
                {
                    if (mistakes > 0)
                    {
                        Console.WriteLine($"\n{HangmanDrawing(mistakes)}");
                    }

                    Console.WriteLine($"\n{PrintWord(crypticWord, guessedLetter, guessedLetterIndex)}"); 

                    guessList = GetGuess(letters, lettercount);
                    if (guessList[0].Equals("true"))
                    {
                        guessedLetter = guessList[1];
                        guessedLetterIndex = int.Parse(guessList[2]);
                        crypticWord = NewList(guessedLetter, guessedLetterIndex, crypticWord);

                        if (guessList.Count() > 3)
                        {
                            int count = guessList.Count();
                            for (int i = 3; i < count; i+=2)
                            {
                                guessedLetter = guessList[i];
                                guessedLetterIndex = int.Parse(guessList[i+1]);
                                crypticWord = NewList(guessedLetter, guessedLetterIndex, crypticWord);
                            }
                        }

                        Console.WriteLine("Your guess was right!");
                        condition = CheckCondition(crypticWord);
                    }
                    else if (mistakes.Equals(9))
                    {
                        Console.WriteLine($"\n{HangmanDrawing(10)}\n");
                        Console.WriteLine("You lost!");
                        PlayAgain();
                    }
                    else
                    {
                        mistakes++;
                        Console.WriteLine("Your guess was wrong!");
                    }

                }
                catch
                {

                }
            }
            Console.WriteLine($"\n{PrintWord(crypticWord, guessedLetter, guessedLetterIndex)}");
            Console.WriteLine($"You won with only {mistakes} mistakes!\n");
            PlayAgain();
 

        }
        static bool CheckCondition(List<string> list)
        {
            if (list.Contains("_"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static List<string> NewList(string letter, int index, List<string> list)
        {
            list[index] = letter;
            return list;
        }

        // Displays the state of the hangman
        static string HangmanDrawing(int iteration)
        {
            switch (iteration)
            {
                case 0:
                    return "";
                case 1:
                    return "/-------\\\r\n|       |";                    
                case 2:
                    return "    | \r\n    | \r\n    | \r\n    |  \r\n/-------\\\r\n|       |";                    
                case 3:
                    return "     _______    \r\n    / \r\n    | \r\n    |  \r\n    |  \r\n    | \r\n/-------\\\r\n|       |";
                case 4:
                    return "     _______    \r\n    /       |\r\n    |  \r\n    |\r\n    |  \r\n    | \r\n/-------\\\r\n|       |\r\n";
                case 5:
                    return "     _______    \r\n    /       |\r\n    |      ( )\r\n    |\r\n    |  \r\n    | \r\n/-------\\\r\n|       |";
                case 6:
                    return "     _______    \r\n    /       |\r\n    |      ( )\r\n    |       |\r\n    |  \r\n    | \r\n/-------\\\r\n|       |";
                case 7:
                    return "     _______    \r\n    /       |\r\n    |      ( )\r\n    |      \\|\r\n    |  \r\n    | \r\n/-------\\\r\n|       |";
                case 8:
                    return "     _______    \r\n    /       |\r\n    |      ( )\r\n    |      \\|/\r\n    |  \r\n    | \r\n/-------\\\r\n|       |";
                case 9:
                    return "     _______    \r\n    /       |\r\n    |      ( )\r\n    |      \\|/\r\n    |       | \r\n    |      / \r\n/-------\\\r\n|       |";
                case 10:
                    return "     _______    \r\n    /       |\r\n    |      ( )\r\n    |      \\|/\r\n    |       | \r\n    |      / \\\r\n/-------\\\r\n|       |\r\n";
            }





            return "0";
        }

        static string PrintWord(List<string> list, string letter, int letterIndex)
        {
            string newString = "Word: ";            

            foreach (string s in list)
            {
                newString = newString + s;
            }

            return newString;
        }

        static List<string> GetGuess(char[] letters, int lettercount)
        {
            bool running = true;
            int multipleOfLetter = 1; // Wie oft ein Buchstabe vorkommt
            List<string> list = new List<string> {"false"}; // Ob Buchstabe vorkommt mit "false" initialisiert

            
            while (running)
            {
                Console.Write("Buchstabe: ");

                string input = (Console.ReadLine()).ToUpper();

                try
                {
                    char guess = char.Parse(input);

                    if (Char.IsLetter(guess))
                    {
                        for (int i = 0; i < lettercount; i++)
                        {
                            if (guess.Equals(letters[i]))
                            {
                                if (multipleOfLetter.Equals(1)) // Wenn es das erste Vorkommen, des Buchstaben ist
                                {
                                    list.RemoveAt(0); // "false" wird entfernt
                                    list.Add("true");
                                    list.Add(guess.ToString()); // Buchstabe, der erraten wurde
                                    list.Add(i.ToString()); // Stelle an die der Buchstabe gehört
                                    multipleOfLetter++;
                                }
                                // Bei jedem weiteren Vorkommen muss nur der Buchstabe und dessen Index hinzugefügt werden:
                                else
                                {
                                    list.Add(guess.ToString());
                                    list.Add(i.ToString());
                                }
                            }
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Bitte Buchstaben eingeben");
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bitte einzelnen Buchstaben eingeben");
                }
            }
            return list;
        }

        // Fragt ob man erneut spielen möchte:
        static void PlayAgain()
        {
            bool running = true;
            string answer = "0";

            Console.WriteLine("Do you want to play again? (y/n)");

            // y = yes: Spiel wird neugestartet;
            // n = no: Spiel wird beendet und Programm geschlossen;
            while (running)
            {
                answer = Console.ReadLine().ToLower();
                try
                {
                    if (answer.Equals("y"))
                    {
                        Restart();
                    }
                    else if (answer.Equals("n"))
                    {
                        Exit();
                    }

                    Console.WriteLine("Please enter (y/n)");

                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter (y/n)");
                }
            }
        }
        // Neustart:
        public static void Restart()
        {
            LoadingAnimation("Restarting Game");
            // Leeren der Konsole vor Neustart:
            Console.Clear();

            Application.Restart();
            // Aktuelle Instanz wird beendet:
            Environment.Exit(0);

        }
        // Beendung:
        public static void Exit()
        {
            LoadingAnimation("Closing Game");

            Environment.Exit(0);
        }
        static void LoadingAnimation(string prompt)
        {
            Console.Write($"\n{prompt}");

            // Kleine Ladeanimation, damit das Programm nicht zu abrupt schließt:
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");

                // Pausiert zwischen Ausgaben für 1/2 Sekunde:
                Thread.Sleep(500);
            }
        }
    }
}
