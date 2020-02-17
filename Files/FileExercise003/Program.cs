using System;
using System.IO;

class FileExercise003
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
            using FileStream fileStream = File.Create(fileName);
            Console.WriteLine("A file created with name MyFile.txt" + System.Environment.NewLine);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadKey();
    }
}