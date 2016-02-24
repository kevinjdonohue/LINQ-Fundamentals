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

        [Test]
        public void ShouldValidateToTrueWhenStringIsA5DigitPostalCode()
        {
            //arrange
            string originalString = "98166";

            //act
            bool isValidPostalCode = originalString.IsValidPostalCode();

            //assert
            isValidPostalCode.Should().BeTrue();
        }

        [Test]
        public void ShouldValidateToTrueWhenStringIsA9DigitPostalCode()
        {
            //arrange
            string originalString = "981661234";

            //act
            bool isValidPostalCode = originalString.IsValidPostalCode();

            //assert
            isValidPostalCode.Should().BeTrue();
        }
    }
}
