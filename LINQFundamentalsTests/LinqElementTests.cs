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
        public void AccessingACollectionWithSingleShouldReturnCauseAnException()
        {
            //arrange
            IEnumerable<Employee> employees = new EmployeeRepository().GetEmployeesWithDepartmentIDs();

            //act
            Action action = () => employees.Single();

            //assert
            action.ShouldThrow<InvalidOperationException>().WithMessage("Sequence contains more than one element");
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
