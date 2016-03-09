using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LinqProjectionsTests
    {
        [Test]
        public void ShouldSelectDistinctWordsFromQuotes()
        {
            //arrange
            string[] famousQuotes =
            {

                "Advertising is legalized lying",
                "Advertising is the greatest art form of the twentieth century"
            };

            //act
            var distinctWords = famousQuotes.SelectMany(w => w.Split(' ')).Distinct();

            //assert
            distinctWords.Should().HaveCount(11);
            distinctWords.Should().ContainInOrder(new string[]
            {
                "Advertising",
                "is",
                "legalized",
                "lying",
                "the",
                "greatest",
                "art",
                "form",
                "of",
                "twentieth",
                "century"
            });
        }
    }
}
