using System;
using System.Collections.Generic;

class LinqExercise7
{
    static void Main(string[] args)
    {
        var templist = new List<int> { 55, 200, 740, 76, 230, 482, 95 };

        foreach (var lstnum in templist)
        {
            Console.Write(lstnum + " ");
        }
        List<int> FilterList = templist.FindAll(x => x > 80 ? true : false);
        Console.WriteLine("Numbers greater than 80:");
        foreach (var num in FilterList)
        {
            Console.WriteLine(num);
        }
        Console.ReadKey();
    }
}