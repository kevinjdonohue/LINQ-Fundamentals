using LINQFundamentals;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LINQWithVarAndAnonymousTypes
    {
        [Test]
        public void DemonstratesVarAndAnonymousTypes()
        {
            //arrange
            var processList = Process.GetProcesses()
                .OrderByDescending(p => p.Threads.Count)
                .ThenBy(p => p.ProcessName)
                .Select(p => new { p.ProcessName, ThreadCount = p.Threads.Count });

            //assert
            foreach (var process in processList)
            {
                Console.WriteLine("{0,25}{1,4:D}", process.ProcessName, process.ThreadCount);
            }
        }

        [Test]
        public void ComparesLINQQuerySyntax()
        {
            //arrange
            var employeeQuery1 =
                from e in new EmployeeRepository().GetAll()
                where e.DepartmentID < 3 && e.ID < 10
                orderby e.DepartmentID descending, e.Name ascending
                select e;

            var employeeQuery3 =
                new EmployeeRepository().GetAll()
                .Where(e => e.DepartmentID < 3 && e.ID < 10)
                .OrderByDescending(e => e.DepartmentID)
                .ThenBy(e => e.Name);

            WriteOutEmployeeList(employeeQuery1, "employeeQuery1");

            WriteOutEmployeeList(employeeQuery3, "employeeQuery3");

        }

        [Test]
        public void DemonstratesGrouping()
        {
            var groupedEmployees =
                from employee in new EmployeeRepository().GetAll()
                group employee by employee.Name[0] into letterGroup
                orderby letterGroup.Key ascending
                select letterGroup;

            var groupedEmployees2 = new EmployeeRepository().GetAll()
                .GroupBy(e => e.Name[0])
                .OrderBy(e => e.Key);

            WriteOutGroupedEmployees(groupedEmployees, "groupedEmployees");

            WriteOutGroupedEmployees(groupedEmployees2, "groupedEmployees2");
        }

        //Temporarily commenting this test out because Linq.Dynamic is not supported on Travis CI
        //[Test]
        //public void DemonstratesDynamicQuery()
        //{
        //    //arrange
        //    var dynamicQuery = new EmployeeRepository().GetAll()
        //        .AsQueryable()
        //        .OrderBy("Name")
        //        .Where("DepartmentID = 1");

        //    //act
        //    foreach (var employee in dynamicQuery)
        //    {
        //        Console.WriteLine(employee.Name);
        //    }
        //}



        private static void WriteOutGroupedEmployees(IOrderedEnumerable<IGrouping<char, Employee>> groupedEmployees, string title)
        {
            Console.WriteLine(title);
            foreach (var group in groupedEmployees)
            {
                Console.WriteLine(group.Key);
                foreach (var employee in group)
                {
                    Console.WriteLine("\t{0}", employee.Name);
                }
            }
        }

        private static void WriteOutEmployeeList(IOrderedEnumerable<Employee> employeeQuery, string title)
        {
            Console.WriteLine(title);
            foreach (var employee in employeeQuery)
            {
                Console.WriteLine(employee.Name);
            }
            Console.WriteLine();
        }
    }
}
