using System;
using System.Linq;

class LinqExercise3
{
    static void Main(string[] args)
    {
        var arr1 = new[] { 3, 9, 2, 8, 6, 5 };

        var sqNo = from int Number in arr1
                   let SqrNo = Number * Number
                   where SqrNo > 20
                   select new { Number, SqrNo };

        foreach (var a in sqNo)
            Console.WriteLine(a);

        Console.ReadKey();
    }
}