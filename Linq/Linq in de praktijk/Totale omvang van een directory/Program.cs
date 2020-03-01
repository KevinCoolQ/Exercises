using System;
using System.Linq;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dInfo = new DirectoryInfo(@"C:/Windows");
            // set bool parameter to false if you do not want to include subdirectories:
            long sizeOfDir = DirectorySize(dInfo, true);

            Console.WriteLine("Directory size in Bytes : " +
            "{0:N0} Bytes", sizeOfDir);
            Console.WriteLine("Directory size in KB : " +
            "{0:N2} KB", ((double)sizeOfDir) / 1024);
            Console.WriteLine("Directory size in MB : " +
            "{0:N2} MB", ((double)sizeOfDir) / (1024 * 1024));

            Console.ReadLine();
        }

        static long DirectorySize(DirectoryInfo dInfo, bool includeSubDir)
        {
            long totalSize = 0; // gebruik dInfo.EnumerateFiles()

            // Enumerate all the files
            // long totalSize = dInfo.EnumerateFiles().Sum(file => file.Length);

            // If Subdirectories are to be included
            if (includeSubDir)
            {
                // Enumerate all sub-directories
                totalSize += 0; // gebruik dInfo.EnumerateDirectories() en roep DirectorySize() opnieuw op - RECURSIEF!
                //totalSize += dInfo.EnumerateDirectories().Sum(dir => DirectorySize(dir, true));
            }
            return totalSize;
        }
    }
}