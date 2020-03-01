using System;
using System.Collections.Generic;
using System.Linq;

public class Students
{
    public string StuName { get; set; }
    public int GrPoint { get; set; }
    public int StuId { get; set; }

    public List<Students> StudentRecords()
    {
        List<Students> studentList = new List<Students>
        {
            new Students { StuId = 1, StuName = "Joseph", GrPoint = 800 },
            new Students { StuId = 2, StuName = "Alex", GrPoint = 458 },
            new Students { StuId = 3, StuName = "Harris", GrPoint = 900 },
            new Students { StuId = 4, StuName = "Taylor", GrPoint = 900 },
            new Students { StuId = 5, StuName = "Smith", GrPoint = 458 },
            new Students { StuId = 6, StuName = "Natasa", GrPoint = 700 },
            new Students { StuId = 7, StuName = "David", GrPoint = 750 },
            new Students { StuId = 8, StuName = "Harry", GrPoint = 700 },
            new Students { StuId = 9, StuName = "Nicolash", GrPoint = 597 },
            new Students { StuId = 10, StuName = "Jenny", GrPoint = 750 }
        };
        return studentList;
    }
}
class LinqExercise11
{
    static void Main(string[] args)
    {
        var e = new Students();

        Console.Write("Maximum grade point (1st, 2nd, 3rd, ...) to find: ");
        int grPointRank = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");

        var stulist = e.StudentRecords();
        var students = (from stuMast in stulist
                        group stuMast by stuMast.GrPoint into g
                        orderby g.Key descending
                        select new
                        {
                            StuRecord = g.ToList()
                        }).ToList();

        students[grPointRank - 1].StuRecord
            .ForEach(i => Console.WriteLine(" Id: {0},  Name: {1}, achieved Grade Point: {2}", i.StuId, i.StuName, i.GrPoint));

        Console.ReadKey();
    }
}