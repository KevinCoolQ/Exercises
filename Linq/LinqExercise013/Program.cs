using System;
using System.Collections.Generic;
using System.Linq;

class LinqExercise13
{
    static void Main(string[] args)
    {
        var listOfString = new List<string> { "m", "n", "o", "p", "q" };

        var _result1 = from y in listOfString
                       select y;

        foreach (var tchar in _result1)
        {
            Console.WriteLine("Char: {0}", tchar);
        }

        string newstr = listOfString.FirstOrDefault(en => en == "o");
        listOfString.Remove(newstr);
        //listOfString.Remove(listOfString.FirstOrDefault(en => en == "p")); 
        //listOfString.RemoveAll(en => en == "p");
        //listOfString.RemoveRange(1, 3);

        var _result = from z in listOfString
                      select z;

        Console.WriteLine("Here is the list after removing the item 'o' from the list:");
        foreach (var rChar in _result)
        {
            Console.WriteLine("Char: {0}", rChar);
        }

        Console.ReadKey();
    }
}
