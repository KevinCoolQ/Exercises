using System;
using System.IO;

class DirectoryCopyExample
{
    private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);
        if (!dir.Exists)
            throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
        DirectoryInfo[] dirs = dir.GetDirectories();
        if (!Directory.Exists(destDirName))
            Directory.CreateDirectory(destDirName);
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(destDirName, file.Name);
            file.CopyTo(temppath, false);
        }
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }

    static void Main(string[] args)
    {
        var numbers = Tuple.Create(1, 2, 3, 4, 5, 6, 7, Tuple.Create(8, 9, 10, 11, 12, 13));
        var a = numbers.Item1; // returns 1
        var b = numbers.Item7; // returns 7
        var c1 = numbers.Rest;
        var c = numbers.Rest.Item1; //returns (8, 9, 10, 11, 12, 13)
        var d = numbers.Rest.Item1.Item1; //returns 8
        var e = numbers.Rest.Item1.Item2; //returns 9

        // Copy from the current directory, include subdirectories.
        //DirectoryCopy(@".\Temp", @".\Temp2", true);
    }
}