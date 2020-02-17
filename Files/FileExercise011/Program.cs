using System;
using System.IO;

class FileExericse011
{
    public static void Main()
    {
        string fileName = @"MyFile.txt";

        try
        {
            // Delete the file if it exists.
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            // Create the file.
            using (StreamWriter fileStream = File.CreateText(fileName))
            {
                fileStream.WriteLine("test line 1");
                fileStream.WriteLine("test line 2");
                fileStream.WriteLine("Test line 3");
            }
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                Console.WriteLine("Content of MyFile.txt:");
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("");
            }

            Console.Write(System.Environment.NewLine + "Content of the first line of the file:" + System.Environment.NewLine);
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                Console.Write(lines[0]);
            }
            Console.WriteLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        Console.ReadKey();
    }
}