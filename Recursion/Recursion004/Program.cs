using System;

class RecExercise4
{
    static void Main(string[] args)
    {
        Console.Write("Specify a number: ");
        int num = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("The number {0} contains {1} digits", num, CountDigits(num, 0));
        Console.ReadKey();
    }

    public static int CountDigits(int n, int numberOfDigits)
    {
        if (n == 0)
            return numberOfDigits;

        return CountDigits(n / 10, ++numberOfDigits);
    }
}