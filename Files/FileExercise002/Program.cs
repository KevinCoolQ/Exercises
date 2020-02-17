using System;
using System.IO;

class FileExercise002
{
    public static void Main()
    {
        string fileName = @"MyFile.txt";

        if (File.Exists(fileName))
        {
            File.Delete(fileName);
            Console.Write("File: {0} is deleted successfully.", fileName);
        }
        else
        {
            Console.Write("File: {0} does not exist", fileName);

        }
        Console.ReadKey();   
    }
}