using System;

class RecursionExercise2
{
	static int PrintNatural(int ctr, int stval)
	{
		// HEEL BELANGRIJK: stopcriterium!
		if (ctr < 1)
		{
			return stval;
		}

		Console.Write("{0} ", ctr);
		ctr--;
		return PrintNatural(ctr, stval);
	}

	static void Main(string[] args)
	{
		Console.Write("Number count to print: ");
		int v = Convert.ToInt32(Console.ReadLine());
		// Call recursive method with two parameters.	
		PrintNatural(v, 1);
		Console.ReadKey();
	}
}