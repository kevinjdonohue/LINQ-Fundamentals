using FluentAssertions;
using LINQFundamentals;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LinqGroupingTests
    {
        [Test]
        public void ShouldReturnNumbersGrouped()
        {
            //arrange
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] expectedOddNumbers = { 1, 3, 5, 7, 9 };
            int[] expectedEvenNumbers = { 2, 4, 6, 8 };

            //act
            var groups = numbers.GroupBy(i => i % 2).ToList();  //modulo 2 value

            //assert
            groups.Should().HaveCount(2);

            var actualOddNumbers = groups[0];
            actualOddNumbers.Should().HaveCount(5);
            actualOddNumbers.Should().Contain(expectedOddNumbers);

            var actualEvenNumbers = groups[1];
            actualEvenNumbers.Should().HaveCount(4);
            actualEvenNumbers.Should().Contain(expectedEvenNumbers);
        }

        [Test]
        public void ShouldGroupEmployeesByDepartment()
        {
            //arrange
            List<Employee> employees = new EmployeeRepository().GetEmployeesWithDepartmentIDs();

            //act
            var groupedEmployees = employees.GroupBy(e => e.DepartmentID).Select(eg => new { DepartmentID = eg.Key, Employees = eg }).ToList();

            //assert
            groupedEmployees.Should().HaveCount(2);

            groupedEmployees[0].DepartmentID.Should().Be(1);
            groupedEmployees[1].DepartmentID.Should().Be(2);

            var engineeringEmployees = groupedEmployees[0].Employees;
            engineeringEmployees.Should().HaveCount(2);

            var salesEmployees = groupedEmployees[1].Employees;
            salesEmployees.Should().HaveCount(1);
        }
    }
}
