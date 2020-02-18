using System;

class RecursionExercise1
{
	static int PrintNatural(int y, int v)
	{		
		if (v < 1)
		{
			return y;
		}
		v--;
		Console.Write("{0} ", y);
		return PrintNatural(y + 1, v);
	}
	static void Main(string[] args)
	{
		Console.Write("Number count to print: ");
		int v = Convert.ToInt32(Console.ReadLine());
		// Call recursive method with two parameters.	
		PrintNatural(1, v);
		Console.ReadKey();
	}
}