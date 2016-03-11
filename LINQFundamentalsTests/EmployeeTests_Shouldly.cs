using LINQFundamentals;
using NUnit.Framework;
using Shouldly;
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
            List<Employee> employees = new EmployeeRepository().GetEmployeesWithHireDates();

            //act
            //IEnumerable<Employee> query = from e in employees
            //                              where e.HireDate.Year < 2005
            //                              orderby e.Name
            //                              select e;

            List<Employee> employeesHiredBefore2005 = employees
                .Where(e => e.HireDate.Year < 2005)
                .OrderBy(e => e.Name).ToList();

            //assert
            employeesHiredBefore2005.ShouldNotBeNull();
            employeesHiredBefore2005.Count.ShouldBe(2);
            employeesHiredBefore2005.ShouldAllBe(e => e.HireDate.Year < 2005);
            employeesHiredBefore2005[0].Name.ShouldBe("Poonam");
            employeesHiredBefore2005[1].Name.ShouldBe("Scott");

        }
    }
}
