using System;
using System.IO;

class FileExercise013
{
	static void Main()
	{
		string fileName = @"MyFile.txt";
		string[] ArrLines;
		int n, i, l;

		if (File.Exists(fileName))
		{
			File.Delete(fileName);
		}
		Console.Write("Specify the number of lines to write: ");
		n = Convert.ToInt32(Console.ReadLine());
		ArrLines = new string[n];
		Console.WriteLine("Specify {0} strings:", n);
		for (i = 0; i < n; i++)
		{
			Console.Write("Specify line {0}: ", i + 1);
			ArrLines[i] = Console.ReadLine();
		}
		System.IO.File.WriteAllLines(fileName, ArrLines);

		Console.Write(System.Environment.NewLine + "Specify which line you want to display:");
		l = Convert.ToInt32(Console.ReadLine());
		if (l >= 1 && l <= n)
		{
			Console.Write(System.Environment.NewLine + "Line {0} of file {1}: " + System.Environment.NewLine, l, fileName);
			if (File.Exists(fileName))
			{
				string[] lines = File.ReadAllLines(fileName);
				Console.WriteLine("{0}", lines[l - 1]);
			}
		}
		else
		{
			Console.WriteLine("Please specify a suitable line number.");
		}

		Console.WriteLine();
		Console.ReadKey();
	}
}