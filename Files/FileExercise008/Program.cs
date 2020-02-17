using System;
using System.IO;

class FileExercise008
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
                fileStream.WriteLine("This is the first line");
                fileStream.WriteLine("of the text file MyFile.txt.");
            }
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                Console.WriteLine("Contents MyFile.txt:");
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("");
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"MyFile.txt", true))
            {
                file.WriteLine("This is the line appended last.");
            }
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                Console.WriteLine("Content of the file after appending a line:");
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadKey();
    }
}