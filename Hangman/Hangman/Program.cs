using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Word words = new Word();

            Dictionary<string, string> collection = words.wordCollection; 

            int count = words.count;

            // Eine random Nummer zwischen eins und der Anzahl der Paare in dem Dictionary
            int randomNumber = GetRandomNumber(1, count);

            string word = Word.GetKey(collection, randomNumber);
            string hint = Word.GetValue(collection, randomNumber);

            Game.StartGame(word, hint);
        }
        // Gibt eine random Nummer zwischen zwei Zahlen zurück:
        public static int GetRandomNumber(int min, int max)
        {
            Random rnd = new Random();
            int random = rnd.Next(min, max);
            return random;
        }
    }
}
