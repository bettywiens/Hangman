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
            List<string> list = Words.GetWord(1);

            int listLength = int.Parse(list[2]);            
            
            int randomNumber = GetRandomNumber(1, listLength);           
            
            list = Words.GetWord(randomNumber);

            string word = list[0];
            string hint = list[1];

            Game.StartGame(word, hint);
        }
        public static int GetRandomNumber(int min, int max)
        {
            Random rnd = new Random();
            int random = rnd.Next(min, max);
            return random;
        }
    }
}
