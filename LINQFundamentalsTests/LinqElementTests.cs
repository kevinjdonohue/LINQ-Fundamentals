using FluentAssertions;
using LINQFundamentals;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LinqElementTests
    {
        [Test]
        public void AccessingAnEmptyCollectionWithFirstShouldCauseAnException()
        {
            //arrange
            IEnumerable<string> empty = Enumerable.Empty<string>();

            //act
            Action action = () => empty.First();

            //assert
            action.ShouldThrow<InvalidOperationException>().WithMessage("Sequence contains no elements");
        }

        [Test]
        public void AccessingACollectionWithFirstShouldReturnTheFirstElementOfTheCollection()
        {
            //arrange
            IEnumerable<Employee> employees = new EmployeeRepository().GetEmployeesWithDepartmentIDs();

            //act
            Employee firstEmployee = employees.First();

            //assert
            firstEmployee.Should().NotBeNull();
            firstEmployee.Name.Should().Be("Scott");
        }

        [Test]
        public void AccessingACollectionWithFirstWithAnIncorrectPredicateShouldCauseAnException()
        {
            //arrange
            IEnumerable<Employee> employees = new EmployeeRepository().GetEmployeesWithDepartmentIDs();

            //act
            Action action = () => employees.First(e => e.Name.StartsWith("X"));

            //assert
            action.ShouldThrow<InvalidOperationException>().WithMessage("Sequence contains no matching element");
        }

        [Test]
        public void AccessingACollectionWithFirstWithACorrectPredicateShouldReturnTheFirstMatchingELement()
        {
            //arrange
            IEnumerable<Employee> employees = new EmployeeRepository().GetEmployeesWithDepartmentIDs();

            //act
            Employee sEmployee = employees.First(e => e.Name.StartsWith("S"));

            //assert
            sEmployee.Should().NotBeNull();
            sEmployee.Name.Should().Be("Scott");

        }

        [Test]
        public void AccessingAnEmptyCollectionWithFirstOrDefaultShouldReturnNull()
        {
            //arrange
            IEnumerable<string> empty = Enumerable.Empty<string>();

            //act
            string result = empty.FirstOrDefault();

            //assert
            result.Should().BeNull();
        }

        [Test]
        public void AccessingACollectionWithFirstOrDefaultShouldFirstElement()
        {
            //arrange
            IEnumerable<Employee> employees = new EmployeeRepository().GetEmployeesWithDepartmentIDs();

            //act
            Employee xEmployee = employees.FirstOrDefault();


            //assert
            xEmployee.Should().NotBeNull();
            xEmployee.Name.Should().Be("Scott");
        }

        [Test]
        public void AccessingACollectionWithFirstOrDefaultWithABadPredicateShouldReturnNull()
        {
            //arrange
            IEnumerable<Employee> employees = new EmployeeRepository().GetEmployeesWithDepartmentIDs();

            //act
            Employee xEmployee = employees.FirstOrDefault(e => e.Name.StartsWith("X"));

            //assert
            xEmployee.Should().BeNull();
        }


        [Test]
        public void AccessingACollectionWithFirstOrDefaultWithAGoodPredicateShouldReturnFirstMatchingElement()
        {
            //arrange
            IEnumerable<Employee> employees = new EmployeeRepository().GetEmployeesWithDepartmentIDs();

            //act
            Employee xEmployee = employees.FirstOrDefault(e => e.Name.StartsWith("P"));

            //assert
            xEmployee.Should().NotBeNull();
            xEmployee.Name.Should().Be("Poonam");
        }

        [Test]
        public void AccessingAnEmptyCollectionWithLastShouldCauseAnException()
        {
            //arrange
            IEnumerable<string> empty = Enumerable.Empty<string>();

            //act
            Action action = () => empty.Last();

            //assert
            action.ShouldThrow<InvalidOperationException>().WithMessage("Sequence contains no elements");
        }

        [Test]
        public void AccessingACollectionWithLastShouldReturnTheLastElementOfTheCollection()
        {
            //arrange
            IEnumerable<Employee> employees = new EmployeeRepository().GetEmployeesWithDepartmentIDs();

            //act
            Employee lastEmployee = employees.Last();

            //assert
            lastEmployee.Should().NotBeNull();
            lastEmployee.Name.Should().Be("Andy");
        }

        [Test]
        public void AccessingAnEmptyCollectionWithLastOrDefaultShouldReturnNull()
        {
            //arrange
            IEnumerable<string> empty = Enumerable.Empty<string>();

            //act
            string result = empty.LastOrDefault();

            //assert
            result.Should().BeNull();
        }

        [Test]
        public void AccessingAnEmptyCollectionWithSingleShouldCauseAnException()
        {
            //arrange
            IEnumerable<string> empty = Enumerable.Empty<string>();

            //act
            Action action = () => empty.Single();

            //assert
            action.ShouldThrow<InvalidOperationException>().WithMessage("Sequence contains no elements");
        }

        [Test]
        public void AccessingACollectionWithSingleShouldCauseAnException()
        {
            //arrange
            IEnumerable<Employee> employees = new EmployeeRepository().GetEmployeesWithDepartmentIDs();

            //act
            Action action = () => employees.Single();

            //assert
            action.ShouldThrow<InvalidOperationException>().WithMessage("Sequence contains more than one element");
        }

        [Test]
        public void AccessingACollectionWithSingleWithABadPredicateShouldCauseAnException()
        {
            //arrange
            IEnumerable<Employee> employees = new EmployeeRepository().GetEmployeesWithDepartmentIDs();

            //act
            Action action = () => employees.Single(e => e.Name.StartsWith("X"));

            //assert
            action.ShouldThrow<InvalidOperationException>().WithMessage("Sequence contains no matching element");
        }

        [Test]
        public void AccessingACollectionWithSingleWithAGoodPredicateShouldReturnElement()
        {
            //arrange
            IEnumerable<Employee> employees = new EmployeeRepository().GetEmployeesWithDepartmentIDs();

            //act
            Employee pEmployee = employees.Single(e => e.Name.StartsWith("P"));

            //assert
            pEmployee.Should().NotBeNull();
            pEmployee.Name.Should().Be("Poonam");
        }

        [Test]
        public void AccessingAnEmptyCollectionWithSingleOrDefaultShouldReturnNull()
        {
            //arrange
            IEnumerable<string> empty = Enumerable.Empty<string>();

            //act
            string result = empty.SingleOrDefault();

            //assert
            result.Should().BeNull();
        }

        [Test]
        public void AccessingAnEmptyCollectionWithElementAtShouldCauseAnException()
        {
            //arrange
            IEnumerable<string> empty = Enumerable.Empty<string>();

            //act
            Action action = () => empty.ElementAt(0);

            //assert
            action.ShouldThrow<ArgumentOutOfRangeException>().WithMessage("Index was out of range. Must be non-negative and less than the size of the collection.\r\nParameter name: index");
        }

        [Test]
        public void AccessingACollectionWithElementAtShouldReturnASpecificElementFromTheCollection()
        {
            //arrange
            IEnumerable<Employee> employees = new EmployeeRepository().GetEmployeesWithDepartmentIDs();

            //act
            Employee secondEmployee = employees.ElementAt(1);

            //assert
            secondEmployee.Should().NotBeNull();
            secondEmployee.Name.Should().Be("Poonam");
        }

        [Test]
        public void AccessingAnEmptyCollectionWithElementAtOrDefaultShouldReturnNull()
        {
            //arrange
            IEnumerable<string> empty = Enumerable.Empty<string>();

            //act
            string result = empty.ElementAtOrDefault(0);

            //assert
            result.Should().BeNull();
        }
    }
}
