using System;
using System.Linq;
using System.IO;

class LinqExercise16
{
    static void Main(string[] args)
    {
        string[] dirfiles = Directory.GetFiles("./");

        var avgFsize = dirfiles.Select(file => new FileInfo(file).Length).Average();

        avgFsize = Math.Round(avgFsize / 10, 1);

        Console.WriteLine("The average file size is {0} Mb", avgFsize);
        Console.ReadKey();
    }
}