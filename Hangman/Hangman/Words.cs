using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Word
    {
        public Dictionary<string, string> wordCollection;
        public int count;
        
        public Word()
        {
            wordCollection = new Dictionary<string, string>
            {
                ["APFEL"] = "Verträgt sich nicht mit Ärzten",
                ["CAPYBARA"] = "Tier, ähnelt einer Kokosnuss",
                ["BANANE"] = "In großen Mengen radioaktiv",
                ["SPHINX"] = "Mythische Kreatur mit einem Löwenkörper und einem Menschenkopf",
                ["RHYTHMUS"] = "Starkes, reguläres, wiederholtes Muster von einer Bewegung oder eines Geräusches",
                ["KRYPTISCH"] = "Wenn etwas eine misteriöse oder obskure Bedeutung haben, ist es ...",
                ["JAZZ"] = "Eine Mischung aus europäischen und westafrikanischen musikalischen Elementen",
                ["KAKERLAKE"] = "Viele sagen, es könnte eine Atombombe überleben",
                ["ANANAS"] = "Umstrittener Pizzabelag",
                ["ANARCHIE"] = "Politisches System: Herschaftslosigkeit",
            };

            count = wordCollection.Count;
        }

        // Gibt {key, value} von einem Dictionary and einem bestimmten index zurück:
        public static List<string> GetWords(Dictionary<string, string> dict, int index)
        {
            int counter = 1;
            List<string> words = new List<string>();

            foreach (KeyValuePair<string, string> word in dict)
            {
                if (counter.Equals(index))
                {
                    words.Add(word.Key);
                    words.Add(word.Value);
                    return words;
                }
                else
                {
                    counter++;
                }
            }
            return words;
        }

        // Nutzt GetWords und gibt nur den Key zurück:
        public static string GetKey(Dictionary<string, string> dict, int index)
        {
            List<string> words = GetWords(dict, index);

            return words[0];
        }

        // Nutzt GetWrods und gibt nur den Value zurück:
        public static string GetValue(Dictionary<string, string> dict, int index)
        {
            List<string> words = GetWords(dict, index);

            return words[1];
        }

    }
}
