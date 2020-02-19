using System;
using System.IO;

class Program
{
    public static void Main()
    {
   
        string fileName = @"./Test/MyFile.txt";
        try
        {
            using FileStream fileStream = File.Create(fileName);
            //File.Delete(fileName);
        }
        catch (System.IO.DirectoryNotFoundException dirEx)
        {
            System.Diagnostics.Debug.WriteLine(dirEx.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Directory.SetCurrentDirectory("c:/projects");

        // . betekent: "huidige directory"
        string root = "./Temp";  // @ staat hier om backslash maar een keer te moeten shrijven

        if (Directory.Exists(root))
        {
            try
            {
                Directory.Delete(root);
                Directory.Delete(root);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        // If directory does not exist, create it.  
        if (!Directory.Exists(root))
        {
            Directory.CreateDirectory(root);
        }
     
        Console.ReadKey();
    }
}