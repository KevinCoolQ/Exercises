using System;
using System.IO;

public class FileExercise009
{
    static void Main()
    {
        string sourceFileName = @"MyFile.txt";
        string targetFileName = @"MyFile2.txt";

        // Delete the file if it exists.
        if (File.Exists(sourceFileName))
        {
            File.Delete(sourceFileName);
        }
        // Create the file.
        using (StreamWriter fileStream = File.CreateText(sourceFileName))
        {
            fileStream.WriteLine("Hello and Welcome.");
            fileStream.WriteLine("This is the first line");
            fileStream.WriteLine("of the text file MyFile.txt.");
        }
        using (StreamReader sr = File.OpenText(sourceFileName))
        {
            string s = "";
            Console.WriteLine("Content of {0}:", sourceFileName);
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("");
        }

        System.IO.File.Copy(sourceFileName, targetFileName, true);
        Console.WriteLine(" The file {0} was successfully copied to {1} in the same directory.", sourceFileName, targetFileName);

        using (StreamReader sr = File.OpenText(targetFileName))
        {
            string s = "";
            Console.WriteLine("Content of {0}:", targetFileName);
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("");
        }
        Console.ReadKey();
    }
}