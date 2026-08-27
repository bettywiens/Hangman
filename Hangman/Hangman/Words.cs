using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Words
    {
        public static List<string> GetWord(int index) {
            
            int counter = 1;

            Dictionary<string, string> wordCollection = new Dictionary<string, string>
            {
                ["APFEL"] = "Verträgt sich nicht mit Ärzten",
                ["CAPYBARA"] = "Tier, ähnelt einer Kokosnuss",
                ["TRUMP"] = "Politik USA, Orange",
                ["BANANE"] = "In großen Mengen radioaktiv",
                ["SPHINX"] = "Mythische Kreatur mit einem Löwenkörper und einem Menschenkopf",
                ["RHYTHMUS"] = "Starkes, reguläres, wiederholtes Muster von einer Bewegung oder eines Geräusches",
                ["KRYPTISCH"] = "Wenn etwas eine misteriöse oder obskure Bedeutung haben, ist es ...",
                ["JAZZ"] = "Eine Mischung aus europäischen und westafrikanischen musikalischen Elementen",

            };


            List<string> words = new List<string>();
            
            foreach (KeyValuePair<string, string> word in wordCollection)
            {
                if (counter.Equals(index))
                {
                    words.Add(word.Key);
                    words.Add(word.Value);
                    words.Add(wordCollection.Count.ToString());
                    return words;
                }
                else
                {
                    counter++;
                }
            }            
            return words;
        }      
    }
}
