using System;
using System.Linq;

class LinqExercise5
{
    static void Main(string[] args)
    {
        string str;

        Console.WriteLine("Specify a string:");
        str = Console.ReadLine();

        var FreQ = from x in str
                   group x by x into y
                   select y;

        Console.WriteLine("The frequency of characters:");
        foreach (var ArrEle in FreQ)
        {
            Console.WriteLine("Character " + ArrEle.Key + " occurs " + ArrEle.Count() + " times");
        }
        Console.ReadKey();
    }
}