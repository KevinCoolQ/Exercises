using System;

/// <summary>
/// Priemgetalln zyn cyfers da j' moa deur twêe getalln kut dêeln noamelik deur êen en deur 't getal zelve (vo een eevn getal ut te komn).
/// Moa 't mag nie êen zelve zyn. Da kan ôok nie wan êen es moa deur êen getal dêelboar, noamelik emzelve.
/// </summary>
class RecursionExercise5
{
    public static int Main(string[] args)
    {
        Console.Write("Specify any positive number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int primeNumber = CheckForPrime(n, n / 2);

        if (primeNumber == 1)
            Console.WriteLine("The number {0} is a prime number.", n);
        else
            Console.WriteLine("The number {0} is not a prime number.", n);
        return 0;
    }

    private static int CheckForPrime(int n, int i)
    {
        if (i == 1)
        {
            return 1;
        }
        else
        {
            if (n % i == 0)
                return 0;
            else
                return CheckForPrime(n, i - 1);
        }
    }
}