using System;
using System.IO;

namespace SubDirList
{
    class Program
    {
        private static void GetSubDirectories()
        {
            string root = @".\Temp";
            LoadSubDirs(root);
        }
        private static void LoadSubDirs(string dir)
        {
            Console.WriteLine(dir);
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            foreach (string subdirectory in subdirectoryEntries)
            {
                LoadSubDirs(subdirectory);
            }
        }

        static void Main(string[] args)
        {
            GetSubDirectories();
            Console.ReadKey();
        }
    }
}
