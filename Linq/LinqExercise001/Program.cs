using System;
using System.Linq;

class LinqExercise1
{
    static void Main()
    {
        int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // Query creation
        // nQuery is an IEnumerable<int>
        var nQuery =
            from VrNum in n1
            where (VrNum % 2) == 0
            select VrNum;

        // Query execution.

        Console.WriteLine("Numbers that produce the remainder 0 after division by 2:");
        foreach (int VrNum in nQuery)
        {
            Console.Write("{0} ", VrNum);
        }
        Console.ReadKey();
    }
}