using System;
using System.Collections.Generic;
using System.Linq;

namespace Uppercase
{
    class Program
    {
        static void Main(string[] args)
        {
            var strwords = FilterWords("THIS is A very STRANGE string");
            foreach (string str in strwords)
                Console.WriteLine(str);
            Console.ReadLine();
        }

        static IEnumerable<string> FilterWords(string str)
        {
            // Geef enkel woorden met uitsluitend hoofdletters terug
            return str.Split(' ');
        }
    }
}