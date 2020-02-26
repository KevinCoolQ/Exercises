using System;
using System.Linq;

class LinqExercise14
{
	public static void Main(string[] args)
	{
		char[] charset1 = { 'X', 'Y', 'Z' };
		int[] numset1 = { 1, 2, 3, 4 };

		Console.WriteLine("LINQ : Generate a Cartesian Product of two sets:");

		var cartesianProduct = from letterList in charset1
							   from numberList in numset1
							   select new { letterList, numberList };

		/*
		     var cartesianProduct = set1.SelectMany(p=> set2.Select(q=> p+q+' '));
		 */

		Console.WriteLine("Cartesian Products:");
		foreach (var productItem in cartesianProduct)
		{
			Console.WriteLine(productItem);
		}
		Console.ReadKey();
	}
}

/*
{ letterList = X, numberList = 1 }                                                                            
{ letterList = X, numberList = 2 }                                                                            
{ letterList = X, numberList = 3 }                                                                            
{ letterList = X, numberList = 4 }                                                                            
{ letterList = Y, numberList = 1 }                                                                            
{ letterList = Y, numberList = 2 }                                                                            
{ letterList = Y, numberList = 3 }                                                                            
{ letterList = Y, numberList = 4 }                                                                            
{ letterList = Z, numberList = 1 }                                                                            
{ letterList = Z, numberList = 2 }                                                                            
{ letterList = Z, numberList = 3 }                                                                            
{ letterList = Z, numberList = 4 } 
 */
