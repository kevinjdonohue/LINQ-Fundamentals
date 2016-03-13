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
        List<Employee> employees;
        List<Department> departments;

        [SetUp]
        public void SetUp()
        {
            employees = new EmployeeRepository().GetEmployeesWithDepartmentIDs();
            departments = new DepartmentRepository().GetDepartments();
        }

        [Test]
        public void ShouldReturnEmployeesWithADepartment()
        {
            //arrange

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
        public void ShouldReturnAllDepartmentsWithTheirRespectiveEmployees()
        {
            //arrange
            List<Employee> expectedEngineeringEmployees = new List<Employee>()
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
                }
            };

            List<Employee> expectedSalesEmployees = new List<Employee>()
            {
                new Employee
                {
                    ID = 3,
                    Name = "Andy",
                    DepartmentID = 2
                }
            };

            //act
            //group join behaves like a SQL OUTER JOIN
            var groupJoinResults = departments.GroupJoin(employees,
                d => d.ID,
                e => e.DepartmentID,
                (d, eg) => new { DepartmentName = d.Name, Employees = eg }).ToList();

            //assert
            groupJoinResults.Should().HaveCount(3);
            groupJoinResults.Should().Equal(departments, (d1, d2) => d1.DepartmentName == d2.Name);

            IEnumerable<Employee> actualEngineeringEmployees = groupJoinResults[0].Employees;
            actualEngineeringEmployees.Should().Equal(expectedEngineeringEmployees, (e1, e2) => e1.Name == e2.Name);

            IEnumerable<Employee> actualSalesEmployees = groupJoinResults[1].Employees;
            actualSalesEmployees.Should().Equal(expectedSalesEmployees, (e1, e2) => e1.Name == e2.Name);

            IEnumerable<Employee> actualSkunkworksEmployees = groupJoinResults[2].Employees;
            actualSkunkworksEmployees.Should().HaveCount(0, "they should not have any employees.");
        }

        [Test]
        public void ShouldReturnDepartmentsWithTheirRespectiveEmployees()
        {
            //arrange
            List<Employee> expectedEngineeringEmployees = new List<Employee>()
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
                }
            };

            List<Employee> expectedSalesEmployees = new List<Employee>()
            {
                new Employee
                {
                    ID = 3,
                    Name = "Andy",
                    DepartmentID = 2
                }
            };

            //act
            //group join behaves like a SQL OUTER JOIN
            var groupJoinResults2 = from department in departments
                                    join employee in employees
                                    on department.ID equals employee.DepartmentID
                                    into employeeGroup
                                    from eg in employeeGroup.DefaultIfEmpty()
                                    select new { department.Name, Employee = eg == null ? "" : eg.Name };

            //TODO:  Figure out how to re-write this query in the lambda syntax instead of this longhand

            //assert
            groupJoinResults2.Should().HaveCount(4);
        }
    }
}
