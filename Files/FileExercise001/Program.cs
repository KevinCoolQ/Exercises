using System;
using System.IO;

class Program
{
    public static void Main()
    {
        string fileName = @"./Test/MyFile.txt";
        try
        {
            //using FileStream fileStream = File.Create(fileName);
            File.Delete(fileName);
        }
        catch(System.IO.DirectoryNotFoundException dirEx)
        {
            System.Diagnostics.Debug.WriteLine(dirEx.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadKey();
    }
}