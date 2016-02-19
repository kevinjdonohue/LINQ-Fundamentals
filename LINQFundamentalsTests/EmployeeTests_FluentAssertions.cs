using FluentAssertions;
using LINQFundamentals;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class EmployeeTests_FluentAssertions
    {
        [Test]
        public void ShouldReturnAListOfEmployeesWithAHireDateGreaterThan2005()
        {
            //arrange   
            IEnumerable<Employee> employees = GetEmployees();

            //act
            //IEnumerable<Employee> employeesHiredBefore2005 = from e in employees
            //                              where e.HireDate.Year < 2002
            //                              orderby e.Name
            //                              select e;

            List<Employee> employeesHiredBefore2005 = employees
                .Where(e => e.HireDate.Year < 2002)
                .OrderBy(e => e.Name).ToList();

            //assert
            employeesHiredBefore2005.Should()
                .NotBeNull()
                .And.NotBeEmpty()
                .And.HaveCount(1, "only one employee was hired before 2002.")
                .And.Contain(e => e.ID == 1 && e.Name == "Scott");
        }

        [Test]
        public void ProvesDeferredExecutionOccursInLINQStatement()
        {
            //arrange
            List<Employee> employees = GetEmployees();
            Employee Scott = employees[0];
            Employee Poonam = employees[1];
            Employee Paul = employees[2];

            //act
            IEnumerable<Employee> employeesHiredBefore2005 = employees.Where(e => e.HireDate.Year < 2005).OrderBy(e => e.Name);

            //add an additional employee (should be included, which proves deferred execution has occurred)
            employees.Add(new Employee() { ID = 4, Name = "Linda", HireDate = new DateTime(2000, 1, 1) });
            Employee Linda = employees[3];

            //assert
            employeesHiredBefore2005.Should().NotBeNullOrEmpty().And.HaveCount(3, "because deferred execution works!");
            employeesHiredBefore2005.Should().Contain(Linda).And.Contain(Scott).And.Contain(Poonam);
            employeesHiredBefore2005.Should().NotContain(Paul);
            employeesHiredBefore2005.Should().StartWith(Linda, "because Linda's name is the first alphabetically, even though it was added last.");
            employeesHiredBefore2005.Should().EndWith(Scott, "because Scott's name is the last alphabetically.");
        }


        private static List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    ID = 1,
                    Name = "Scott",
                    HireDate = new DateTime(2001, 3, 5)
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
        }
    }
}
