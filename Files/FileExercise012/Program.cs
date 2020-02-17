using System;
using System.IO;

class FileExercise012
{
	static void Main()
	{
		string fileName = @"MyFile.txt";
		string[] ArrLines;
		int n, i;

		if (File.Exists(fileName))
		{
			File.Delete(fileName);
		}
		Console.Write("Specify number of lines to write: ");
		n = Convert.ToInt32(Console.ReadLine());
		ArrLines = new string[n];
		Console.Write("Specify {0} strings:" + System.Environment.NewLine, n);
		for (i = 0; i < n; i++)
		{
			Console.Write("Specify line {0}: ", i + 1);
			ArrLines[i] = Console.ReadLine();
		}
		System.IO.File.WriteAllLines(fileName, ArrLines);
		Console.Write("The last line of file {0} is:" + System.Environment.NewLine, fileName);
		if (File.Exists(fileName))
		{
			string[] lines = File.ReadAllLines(fileName);
			Console.WriteLine("{0}", lines[n - 1]);
		}
		Console.WriteLine();
		Console.ReadKey();
	}
}