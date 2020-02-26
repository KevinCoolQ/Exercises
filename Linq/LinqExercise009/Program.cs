using System;
using System.Linq;

class LinqExercise9
{
    static void Main(string[] args)
    {
        string[] stringArray;
        int n, i;

        Console.Write("Specify number of strings to store in the array: ");
        n = Convert.ToInt32(Console.ReadLine());
        stringArray = new string[n];
        Console.WriteLine("Specify {0} strings for the array:", n);
        for (i = 0; i < n; i++)
        {
            Console.Write("Element[{0}] : ", i);
            stringArray[i] = Console.ReadLine();
        }

        string newstring = String.Join(", ", stringArray
                      .Select(s => s.ToString())
                      .ToArray());

        Console.Write(System.Environment.NewLine + "Resulting string: ");
        Console.WriteLine(newstring);
        Console.ReadKey();
    }
}