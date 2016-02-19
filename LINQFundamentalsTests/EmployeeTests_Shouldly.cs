using LINQFundamentals;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class EmployeeTests_Shouldly
    {
        [Test]
        public void Shouldly_ShouldReturnAListOfEmployeesWithAHireDateGreaterThan2005()
        {
            //arrange   
            IEnumerable<Employee> employees = new List<Employee>()
            {
                new Employee
                {
                    ID = 1,
                    Name = "Scott",
                    HireDate = new DateTime(2002, 3, 5)
                },
                new Employee
                {
                    ID = 2,
                    Name = "Poonam",
                    HireDate = new DateTime(2002, 10, 15)
                },
                new Employee
                {
                    ID = 3,
                    Name = "Paul",
                    HireDate = new DateTime(2007, 10, 11)
                }
            };

            //List<Employee> expectedEmployees = new List<Employee>() {
            //    new Employee
            //    {
            //        ID = 1,
            //        Name = "Scott",
            //        HireDate = new DateTime(2002, 3, 5)
            //    },
            //    new Employee
            //    {
            //        ID = 2,
            //        Name = "Poonam",
            //        HireDate = new DateTime(2002, 10, 15)
            //    }
            //};

            //act
            //IEnumerable<Employee> query = from e in employees
            //                              where e.HireDate.Year < 2005
            //                              orderby e.Name
            //                              select e;

            List<Employee> employeesHiredBefore2005 = employees.Where(e => e.HireDate.Year < 2005).OrderBy(e => e.Name).ToList();

            //assert
            employeesHiredBefore2005.ShouldNotBeNull();
            employeesHiredBefore2005.Count.ShouldBe(2);
            employeesHiredBefore2005.ShouldAllBe(e => e.HireDate.Year < 2005);
            employeesHiredBefore2005[0].Name.ShouldBe("Poonam");
            employeesHiredBefore2005[1].Name.ShouldBe("Scott");

        }
    }
}
