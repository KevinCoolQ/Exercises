using System;
using System.IO;

class FileExercise005
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
                fileStream.WriteLine("Hello and Welcome.");
                fileStream.WriteLine("This is the second line");
                fileStream.WriteLine("of the text file MyFile.txt.");
            }
            using StreamReader sr = File.OpenText(fileName);
            string s = "";
            Console.WriteLine("Content of the file MyFile.txt: ");
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadKey();
    }
}