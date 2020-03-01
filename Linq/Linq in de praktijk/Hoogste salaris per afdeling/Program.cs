using System.Collections.Generic;
using System.Linq;

namespace Hoogste_salaris_per_afdeling
{
    class Employees
    {
        public int EmpId { get; set; }
        public int DeptId { get; set; }
        public int Salary { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employees> employees = new List<Employees>
            {
                new Employees() { EmpId = 1, DeptId = 1, Salary = 20000 },
                new Employees() { EmpId = 2, DeptId = 1, Salary = 21000 },
                new Employees() { EmpId = 3, DeptId = 1, Salary = 18000 },
                new Employees() { EmpId = 4, DeptId = 1, Salary = 33000 },
                new Employees() { EmpId = 5, DeptId = 2, Salary = 17000 },
                new Employees() { EmpId = 6, DeptId = 2, Salary = 21000 },
                new Employees() { EmpId = 7, DeptId = 2, Salary = 19000 },
                new Employees() { EmpId = 8, DeptId = 2, Salary = 34000 },
                new Employees() { EmpId = 9, DeptId = 2, Salary = 54000 },
                new Employees() { EmpId = 10, DeptId = 3, Salary = 24000 },
                new Employees() { EmpId = 11, DeptId = 3, Salary = 21000 },
                new Employees() { EmpId = 12, DeptId = 3, Salary = 16000 },
                new Employees() { EmpId = 13, DeptId = 3, Salary = 52000 },
                new Employees() { EmpId = 14, DeptId = 4, Salary = 22000 },
                new Employees() { EmpId = 15, DeptId = 4, Salary = 66000 },
                new Employees() { EmpId = 16, DeptId = 4, Salary = 21000 }
            };

            // Druk het hoogste salaris per afdeling af
        }
    }
}
