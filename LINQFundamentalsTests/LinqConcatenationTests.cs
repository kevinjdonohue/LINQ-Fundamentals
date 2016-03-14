using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LinqConcatenationTests
    {
        [Test]
        public void ShouldReturnAllItemsFromTwoLists()
        {
            //arrange
            string[] firstNames = { "Kevin", "Kim", "Chris", "Kate" };
            string[] lastNames = { "Donohue", "Stantus", "Harang", "Cassidy" };

            //act 
            IEnumerable<string> firstAndLastNames = firstNames.Concat(lastNames);

            //assert
            firstAndLastNames.Should().HaveCount(8);
            firstAndLastNames.Should().StartWith("Kevin");
            firstAndLastNames.Should().EndWith("Cassidy");
        }

        [Test]
        public void ShouldReturnAllItemsFromTwoListsOrderedByNames()
        {
            //arrange
            string[] firstNames = { "Kevin", "Kim", "Chris", "Kate" };
            string[] lastNames = { "Donohue", "Stantus", "Harang", "Cassidy" };

            //act 
            IEnumerable<string> firstAndLastNames = firstNames.Concat(lastNames).OrderBy(fnl => fnl);

            //assert
            firstAndLastNames.Should().HaveCount(8);
            firstAndLastNames.Should().StartWith("Cassidy");
            firstAndLastNames.Should().EndWith("Stantus");
        }
    }
}
