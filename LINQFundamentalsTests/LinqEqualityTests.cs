using FluentAssertions;
using LINQFundamentals;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LinqEqualityTests
    {
        [Test]
        public void ShouldDetermineTwoSequencesAreNotEqual()
        {
            //arrange
            Employee e1 = new Employee() { ID = 1, Name = "Employee1" };
            Employee e2 = new Employee() { ID = 2, Name = "Employee2" };
            Employee e3 = new Employee() { ID = 3, Name = "Employee3" };
            List<Employee> employees1 = new List<Employee>() { e1, e2, e3 };
            List<Employee> employees2 = new List<Employee>() { e2, e3, e1 };

            //act
            bool areEqualLists = employees1.SequenceEqual(employees2);

            //assert
            areEqualLists.Should().BeFalse();
        }

        [Test]
        public void ShouldDetermineTwoSequencesAreEqual()
        {
            //arrange
            Employee e1 = new Employee() { ID = 1, Name = "Employee1" };
            Employee e2 = new Employee() { ID = 2, Name = "Employee2" };
            Employee e3 = new Employee() { ID = 3, Name = "Employee3" };
            List<Employee> employees1 = new List<Employee>() { e1, e2, e3 };
            List<Employee> employees2 = new List<Employee>() { e1, e2, e3 };

            //act
            bool areEqualLists = employees1.SequenceEqual(employees2);

            //assert
            areEqualLists.Should().BeTrue();
        }
    }
}
