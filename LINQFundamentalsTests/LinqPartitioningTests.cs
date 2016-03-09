using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LinqPartitioningTests
    {
        [Test]
        public void ShouldSkipAndTakeCorrectly()
        {
            //arrange
            int[] numbers = { 1, 2, 3, 5, 8, 13, 20, 40, 100 };

            //act
            var result = numbers.Skip(6).Take(3);  //great for things like pagination

            //assert
            result.Should().HaveCount(3);
            result.Should().ContainInOrder(new int[] { 20, 40, 100 });
        }

        [Test]
        public void ShouldSkipWhileAndTakeWhileCorrectly()
        {
            //arrange
            int[] numbers = { 1, 2, 3, 5, 8, 13, 20, 40, 100 };

            //act
            var result = numbers.SkipWhile(n => n < 13).TakeWhile(n => n < 40);

            //assert
            result.Should().HaveCount(2);
            result.Should().ContainInOrder(new int[] { 13, 20 });
        }
    }
}
