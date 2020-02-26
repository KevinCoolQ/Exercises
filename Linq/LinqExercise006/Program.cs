using System;
using System.Linq;

class LinqExercise6
{
    static void Main(string[] args)
    {
        string chst, chen;
        char ch;
        string[] cities =
        {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };

        Console.WriteLine("Find strings that start and end with a specific character:");
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("The cities are : 'ROME','LONDON','NAIROBI','CALIFORNIA','ZURICH','NEW DELHI','AMSTERDAM','ABU DHABI','PARIS'");

        Console.Write("Specify starting character: ");
        ch = (char)Console.Read();
        chst = ch.ToString();
        Console.WriteLine(System.Environment.NewLine + "Specify ending character:");
        ch = (char)Console.Read();
        chen = ch.ToString();

        var _result = from x in cities
                      where x.StartsWith(chst)
                      where x.EndsWith(chen)
                      select x;
 
        foreach (var city in _result)
        {
            Console.WriteLine("The city starting with {0} and ending with {1} is: {2}", chst, chen, city);
        }

        Console.ReadKey();
    }
}