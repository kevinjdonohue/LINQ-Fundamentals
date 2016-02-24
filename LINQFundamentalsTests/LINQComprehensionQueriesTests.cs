using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LINQComprehensionQueriesTests
    {
        [Test]
        public void DemonstratesComprehensionQuery()
        {
            //arrange
            string[] cities = { "Boston", "Los Angeles", "Seattle", "London", "Hyderabad", "Lisbon" };

            //act
            IEnumerable<string> filteredCities =
              from city in cities
              where city.StartsWith("L") && city.Length < 15
              orderby city
              select city;

            //compiler transforms this query expression into this lambda expression:
            //IEnumerable<string> filteredCities = cities.Where(c => c.StartsWith("L") && c.Length < 15).OrderBy(c => c).Select(c => c);

            //assert
            filteredCities.Should().NotBeNullOrEmpty();
            filteredCities.Should().HaveCount(3);
            filteredCities.Should().BeInAscendingOrder();
            filteredCities.Should().Contain("London").And.Contain("Los Angeles").And.Contain("Lisbon");

        }
    }
}
