using System;
using System.IO;

class FileExercise015
{
    public static void Main()
    {
        string fileName = @"MyFile.txt";
        int count;

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
                fileStream.WriteLine(" test line 1");
                fileStream.WriteLine(" test line 2");
                fileStream.WriteLine(" Test line 3");
                fileStream.WriteLine(" test line 4");
                fileStream.WriteLine(" test line 5");
                fileStream.WriteLine(" Test line 6");
            }
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                count = 0;
                Console.WriteLine("Content of file MyFile.txt:");
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                    count++;
                }
                Console.WriteLine("");
            }
            Console.Write("Line count of file {0}: {1}\n\n", fileName, count);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadKey();
    }
}