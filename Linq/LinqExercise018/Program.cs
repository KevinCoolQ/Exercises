using System;
using System.Linq;
using System.Collections.Generic;

class LinqExercise18
{
    static void Main(string[] args)
    {

        string[] cities =
           {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };

        Console.WriteLine("Display the list first according to the length and then by name in ascending order");

        IEnumerable<string> cityOrder =
        cities.OrderBy(str => str.Length)
                        .ThenBy(str => str);
        foreach (string city in cityOrder)
            Console.WriteLine(city);
        Console.ReadKey();
    }
}