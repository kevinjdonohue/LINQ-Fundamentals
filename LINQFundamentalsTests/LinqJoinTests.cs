using FluentAssertions;
using LINQFundamentals;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LinqJoinTests
    {
        [Test]
        public void ShouldReturnEmployeesWithADepartment()
        {
            //arrange
            var employees = GetEmployees();
            var departments = GetDepartments();

            //act
            //join behaves like a SQL INNER JOIN
            var joinResultsOrderedByEmployeeName = departments.Join(employees,
                d => d.ID,
                e => e.DepartmentID,
                (d, e) => new { DepartmentName = d.Name, EmployeeName = e.Name }).OrderBy(r => r.EmployeeName);

            //assert
            joinResultsOrderedByEmployeeName.Should().HaveCount(3);
            joinResultsOrderedByEmployeeName.Should().ContainInOrder(new[]
            {
                new { DepartmentName = "Sales", EmployeeName = "Andy" },
                new { DepartmentName = "Engineering", EmployeeName = "Poonam" },
                new { DepartmentName = "Engineering", EmployeeName = "Scott" }
            });
        }

        [Test]
        public void ShouldReturnDepartmentsWithTheirRespectiveEmployees()
        {
            //arrange
            var employees = GetEmployees();
            var departments = GetDepartments();

            //act
            var groupJoinResults = departments.GroupJoin(employees,
                d => d.ID,
                e => e.DepartmentID,
                (d, eg) => new { DepartmentName = d.Name, Employees = eg });

            //assert
            groupJoinResults.Should().HaveCount(3);
            //TODO:  Need to figure out how to verify the group join results have the correct contents
        }






        private List<Department> GetDepartments()
        {
            return new List<Department>()
            {
                new Department()
                {
                    ID = 1,
                    Name = "Engineering"
                },
                new Department()
                {
                    ID = 2,
                    Name = "Sales"
                },
                new Department()
                {
                    ID = 3,
                    Name = "Skunkworks"
                }
            };
        }

        private List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    ID = 1,
                    Name = "Scott",
                    DepartmentID = 1
                },
                new Employee
                {
                    ID = 2,
                    Name = "Poonam",
                    DepartmentID = 1
                },
                new Employee
                {
                    ID = 3,
                    Name = "Andy",
                    DepartmentID = 2
                }
            };
        }
    }
}
