using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using LINQFundamentals;
using NUnit.Framework;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class SelectTests
    {
        [Test]
        public void ProjectListOfNamesIntoAListOfEmployees()
        {
            // arrange
            List<string> names = new List<string>
            {
                "Kevin",
                "Adam",
                "Geoff"
            };

            // act
            IEnumerable<Test> employees = names.Select(n =>
                new Test {
                    id = 1,
                    name = n              
                });

            // assert            
            employees.Should().HaveCount(3);
        }
    }

    internal class Test
    {
        public int id { get; set; }
        public string name { get; set; }    
    }
}