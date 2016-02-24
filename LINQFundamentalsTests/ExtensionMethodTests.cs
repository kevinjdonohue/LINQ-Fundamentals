using FluentAssertions;
using LINQFundamentals;
using NUnit.Framework;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class ExtensionMethodTests
    {
        [Test]
        public void ShouldParseAStringIntoADouble()
        {
            //arrange
            string originalString = "10.00";

            //act
            double result = originalString.ToDouble();

            //assert
            result.Should().Be(10.00);
        }
    }
}
