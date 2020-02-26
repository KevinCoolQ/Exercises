using System;
using System.Linq;

class LinqExercise4
{
    static void Main(string[] args)
    {
        int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };

        var n = from x in arr1
                group x by x into y
                select y;

        foreach (var arrNo in n)
        {
            Console.WriteLine("Number " + arrNo.Key + " appears " + arrNo.Count() + " times");
        }
        Console.ReadKey(); ;
    }
}