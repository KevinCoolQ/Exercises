using System;
using System.IO;

class FilExcerise007
{
    static void Main()
    {
        string fileName = @"MyFile.txt";
        string[] ArrLines;
        string str;

        int n, i;

        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }
        Console.Write("Specify the line string to ignore: ");
        str = Console.ReadLine();
        Console.Write("Specify the number of lines to write: ");
        n = Convert.ToInt32(Console.ReadLine());
        ArrLines = new string[n];

        Console.Write("Specify {0} strings:" + System.Environment.NewLine, n);
        for (i = 0; i < n; i++)
        {
            Console.Write("Line {0}: ", i + 1);
            ArrLines[i] = Console.ReadLine();
        }

        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"MyFile.txt"))
        {
            foreach (string line in ArrLines)
            {
                if (!line.Contains(str)) // write the line to the file If it doesn't contain the string in str
                {
                    file.WriteLine(line);
                }
            }
        }

        using StreamReader sr = File.OpenText(fileName);
        string s = "";
        Console.Write(System.Environment.NewLine + "The line that contains the string '{0}' is ignored." + System.Environment.NewLine, str);
        Console.Write(System.Environment.NewLine + "Content:" + System.Environment.NewLine, n);
        Console.Write("--------" + System.Environment.NewLine);
        while ((s = sr.ReadLine()) != null)
        {
            Console.WriteLine("{0}", s);
        }
        Console.WriteLine();
        Console.ReadKey();
    }
}