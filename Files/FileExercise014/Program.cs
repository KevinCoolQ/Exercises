using System;
using System.IO;

class FileExercise014
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
		Console.WriteLine("Specify {0} strings below:", n);
		for (i = 0; i < n; i++)
		{
			Console.Write("Specify line {0}: ", i + 1);
			ArrLines[i] = Console.ReadLine();
		}
		System.IO.File.WriteAllLines(fileName, ArrLines);

		Console.Write("Specify how many lines you want to display: ");
		l = Convert.ToInt32(Console.ReadLine());
		int m = l;
		if (l >= 1 && l <= n)
		{
			Console.WriteLine(System.Environment.NewLine + "Last {0} lines of file {1}:", l, fileName);
			if (File.Exists(fileName))
			{
				for (i = n - l; i < n; i++)
				{
					string[] lines = File.ReadAllLines(fileName);
					Console.Write("Line {0}: {1} \n", m, lines[i]);
					m--;
				}
			}
		}
		else
		{
			Console.WriteLine("Please input a suitable line number.");
		}

		Console.WriteLine();
		Console.ReadKey();
	}
}