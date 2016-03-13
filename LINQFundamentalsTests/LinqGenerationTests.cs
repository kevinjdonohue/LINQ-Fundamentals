using FluentAssertions;
using LINQFundamentals;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LinqGenerationTests
    {
        [Test]
        public void ShouldReturnAnEmptyCollection()
        {
            //act
            IEnumerable<Employee> employees = Enumerable.Empty<Employee>();

            //assert
            employees.Should().BeOfType<Employee[]>();
            employees.Should().BeEmpty();
        }

        [Test]
        public void ShouldReturnARangeOfNumbers()
        {
            //act
            IEnumerable<int> rangeOfNumbers = Enumerable.Range(1, 10);

            //assert
            rangeOfNumbers.Should().HaveCount(10);
            rangeOfNumbers.Should().ContainInOrder(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        [Test]
        public void ShouldReturnASequenceOfSquares()
        {
            //act
            IEnumerable<int> squares = Enumerable.Range(2, 6).Select(n => n * n);

            //assert
            squares.Should().HaveCount(6);
            squares.Should().ContainInOrder(new List<int> { 4, 9, 16, 25, 36, 49 });
        }

        [Test]
        public void ShouldReturnASequenceOfRepeatedIntegers()
        {
            //act 
            IEnumerable<int> oneHundreds = Enumerable.Repeat(100, 5);

            //assert
            oneHundreds.Should().HaveCount(5);
            oneHundreds.Should().ContainInOrder(new List<int> { 100, 100, 100, 100, 100 });
        }

        [Test]
        public void ShouldReturnASequenceOfRepeatedItems()
        {
            //act
            IEnumerable<Employee> repeatedEmployees = Enumerable.Repeat<Employee>(new Employee() { DepartmentID = 1, Name = "Employee" }, 5);

            //assert
            repeatedEmployees.Should().HaveCount(5);
            repeatedEmployees.Select(e => e.DepartmentID == 1 && e.Name == "Employee").Count().Should().Be(5);
        }
    }
}
