using FluentAssertions;
using NUnit.Framework;
using System;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LambdaExpressionTests
    {
        [Test]
        public void DemonstratesActionDelegateWithNoParameters()
        {
            //arrange
            const string employeeName = "Scott";
            string assignedName = null;
            Action printName = () => assignedName = employeeName;

            //act
            printName();

            //assert
            assignedName.Should().NotBeNullOrWhiteSpace("we assigned the named Scott inside the action delegate.");
            assignedName.Should().Be(employeeName);
        }

        [Test]
        public void DemonstratesActionDelegateWithASingleArgument()
        {
            //arrange
            int assignedInteger = 0;
            Action<int> printNumber = n => assignedInteger = n;

            //act
            printNumber(10);

            //assert
            assignedInteger.Should().NotBe(0);
            assignedInteger.Should().Be(10, "we assigned 10 inside the action delegate.");
        }

        [Test]
        public void DemonstratesActionDelegateWithTwoArguments()
        {
            //arrange
            string actualName = null;
            int actualAge = 0;
            Action<string, int> printNameAndAge = (name, age) => { actualName = name; actualAge = age; };

            const string expectedName = "Scott";
            int expectedAge = 40;

            //act
            printNameAndAge("Scott", 40);

            //assert
            actualName.Should().NotBeNullOrWhiteSpace();
            actualName.Should().Be(expectedName, "we passed in the name Scott to the Action delegate.");
            actualAge.Should().NotBe(0);
            actualAge.Should().Be(expectedAge, "we passed in the age 40 to the Action delegate.");
        }

        [Test]
        public void DemonstratesFuncDelegateWithNoParametersThatReturnsADateTime()
        {
            //arrange
            Func<DateTime> getDateTime = () => new DateTime(1973, 9, 19);

            DateTime expectedDateTime = new DateTime(1973, 9, 19);

            //act
            DateTime actualDateTime = getDateTime();

            //assert
            actualDateTime.Should().Be(expectedDateTime);
        }

        [Test]
        public void DemonstratesFuncDelegateWithSingleIntParameterThatReturnsAnInt()
        {
            //arrange
            Func<int, int> square = x => x * x;

            //act
            int squareOfTwo = square(2);

            //assert
            squareOfTwo.Should().Be(4);
        }

        [Test]
        public void DemonstratesFuncDelegateWithTwoIntParametersThatReturnsAnInt()
        {
            //arrange
            Func<int, int, int> multiply = (x, y) => x * y;

            //act
            int threeTimesThree = multiply(3, 3);

            //assert
            threeTimesThree.Should().Be(9);
        }
    }
}
