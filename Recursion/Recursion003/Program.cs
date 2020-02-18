using System;
class RecursionExercise3
{ 
    private static int Sum(int min, int val)
    {
        // STOPCRITERIUM: BELANGRIJKSTE van recursieve functieoproep, is meteen het kleinste, makkelijkste geval
        if (val == min)
            return val;
        return val + Sum(min, val - 1);
    }

    static void Main(string[] args)
    {
        Console.Write("Number count to sum: ");
        int n = Convert.ToInt32(Console.ReadLine());
        try
        {
            // We berekenen de som via de CALL STACK:
            Console.WriteLine("The sum of the first {0} natural numbers is: {1}", n, Sum(1, n));
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadKey();
    }

 
}