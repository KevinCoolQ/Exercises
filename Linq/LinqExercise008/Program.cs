using System;
using System.Collections.Generic;
using System.Linq;

class LinqExercise9
{
    static void Main(string[] args)
    {
        var templist = new List<int>{ 5, 7, 13, 24, 6, 9, 8, 7 };

        foreach (var lstnum in templist)
        {
            Console.Write(lstnum + " ");
        }        

        Console.Write(System.Environment.NewLine + "How many records do you want to show? ");
        int n = Convert.ToInt32(Console.ReadLine());

        templist.Sort();
        templist.Reverse();

        Console.WriteLine(System.Environment.NewLine + "The top {0} records:", n);
        foreach (int topn in templist.Take(n))
        {
            Console.Write(topn + " ");
        }
        Console.ReadKey();
    }
}
