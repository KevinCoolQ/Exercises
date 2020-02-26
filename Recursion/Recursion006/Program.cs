using System;

class Permutation
{
    public void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    public void PrintPermutation(int[] list, int k, int m)
    {
        int i;
        if (k == m)
        {
            for (i = 0; i <= m; i++)
                Console.Write("{0}", list[i]);
            Console.Write(" ");
        }
        else
            for (i = k; i <= m; i++)
            {
                Swap(ref list[k], ref list[i]);
                PrintPermutation(list, k + 1, m);
                Swap(ref list[k], ref list[i]);
            }
    }
}

class RecursionExercise6
{
    public static void Main()
    {
        int n, i;
        Permutation permutation = new Permutation();
        int[] arrayValues = new int[5];

        Console.Write("Specify the number of elements to store in the array (maximum 5 digits): ");
        n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Specify {0} number of elements in the array:", n);
        for (i = 0; i < n; i++)
        {
            Console.Write("Element {0}: ", i);
            arrayValues[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("The permutations of {0} digits are:", n);
        permutation.PrintPermutation(arrayValues, 0, n - 1);
        Console.ReadKey();
    }
}