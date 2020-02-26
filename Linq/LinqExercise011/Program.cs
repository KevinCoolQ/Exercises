using System;
using System.Linq;
using System.IO;

class LinqExercise11
{
    public static void Main()
    {
        string[] arr1 = { "aaa.frx", "bbb.TXT", "xyz.dbf", "abc.pdf", "aaaa.PDF", "xyz.frt", "abc.xml", "ccc.txt", "zzz.txt" };

        var fGrp = arr1.Select(file => Path.GetExtension(file).TrimStart('.').ToLower())
                 .GroupBy(z => z, (fExt, extCtr) => new
                 {
                     Extension = fExt,
                     Count = extCtr.Count()
                 });

        foreach (var m in fGrp)
            Console.WriteLine("{0} File(s) with extension {1}", m.Count, m.Extension);
        Console.ReadKey();
    }
}