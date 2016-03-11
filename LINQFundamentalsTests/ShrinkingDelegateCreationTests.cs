using FluentAssertions;
using LINQFundamentals;
using NUnit.Framework;
using System;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class ShrinkingDelegateCreationTests
    {
        Employee[] employees;

        [SetUp]
        public void SetUp()
        {
            employees = new EmployeeRepository().GetArrayOfEmployeesWithHireDates();
        }

        [Test]
        public void DemonstratesPredicate()
        {
            //arrange
            const string expectedEmployeeName = "Scott";

            //act
            Employee foundEmployee = Array.Find(employees, findScottPredicate);

            //assert
            foundEmployee.Name.Should().Be(expectedEmployeeName);
        }

        [Test]
        public void DemonstratesDelegate()
        {
            //arrange
            const string expectedEmployeeName = "Scott";
            const string searchToken = "Scott";

            //act
            Employee foundEmployee = Array.Find(employees,
                delegate (Employee employee) { return (employee.Name == searchToken); });

            //assert
            foundEmployee.Name.Should().Be(expectedEmployeeName);
        }

        [Test]
        public void DemonstratesVerboseLambdaExpression()
        {
            //arrange
            const string expectedEmployeeName = "Scott";
            const string searchToken = "Scott";

            //act
            //drop the delegate keyword, Type (Employee) - type inference leveraged
            //adds the "goes to" operator (=>)
            Employee foundEmployee = Array.Find(employees, (e) => { return (e.Name == searchToken); });

            //assert
            foundEmployee.Name.Should().Be(expectedEmployeeName);
        }

        [Test]
        public void DemonstratesShortLambdaExpression()
        {
            //arrange
            const string expectedEmployeeName = "Scott";
            const string searchToken = "Scott";

            //act
            //drop the parentheses, curly braces (single parameter), return keyword 
            //and semicolon to shorten up the expression even more
            Employee foundEmployee = Array.Find(employees, e => e.Name == searchToken);

            //assert
            foundEmployee.Name.Should().Be(expectedEmployeeName);
        }





        /// <summary>
        /// Old Style Predicate - Named method for executing some search in our array
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        private bool findScottPredicate(Employee employee)
        {
            return (employee.Name == "Scott");
        }
    }
}
