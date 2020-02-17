using System;
using System.IO;

public class FileExercise010
{
    static void Main()
    {

        string sourceFileName = @"MyFile.txt";
        string targetFileName = @"MyFile3.txt";

        if (File.Exists(sourceFileName))
        {
            File.Delete(sourceFileName);
        }
        if (File.Exists(targetFileName))
        {
            File.Delete(targetFileName);
        }
        // Create the file.
        using (StreamWriter fileStream = File.CreateText(sourceFileName))
        {
            fileStream.WriteLine("Hello and Welcome.");
            fileStream.WriteLine("This is the first content");
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
        System.IO.File.Move(sourceFileName, targetFileName); // move a file to another name in same location
        Console.WriteLine(" The file {0} was successfully moved to {1} in the same directory.", sourceFileName, targetFileName);

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