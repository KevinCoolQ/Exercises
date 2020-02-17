using System;
using System.IO;

class WriteTextFile
{
    static void Main()
    {
        string fileName = @"MyFile.txt";

        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        Console.Write("Specify number of lines to write: ");
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arrayLines = new string[n];
        Console.Write("Specify {0} strings:" + System.Environment.NewLine, n);
        for (var i = 0; i < n; i++)
        {
            Console.Write("Line {0}: ", i + 1);
            arrayLines[i] = Console.ReadLine();
        }
        System.IO.File.WriteAllLines(fileName, arrayLines);

        using StreamReader sr = File.OpenText(fileName);
        string s = "";
        Console.Write(System.Environment.NewLine + "Content:" + System.Environment.NewLine, n);
        Console.Write("--------" + System.Environment.NewLine);
        while ((s = sr.ReadLine()) != null)
        {
            Console.WriteLine(s);
        }
        Console.WriteLine();
        Console.ReadKey();
    }
}