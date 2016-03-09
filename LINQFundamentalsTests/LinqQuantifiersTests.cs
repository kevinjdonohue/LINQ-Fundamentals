using FluentAssertions;
using LINQFundamentals;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LinqQuantifiersTests
    {
        [Test]
        public void ShouldReturnAllNumbersThatSatisfyModulus()
        {
            //arrange
            int[] evenNumbers = { 2, 4, 6, 8 };

            //act
            bool areAllEvenNumbers = evenNumbers.All(n => n % 2 == 0);
            bool containsMultipleOfThree = evenNumbers.Any(n => n % 3 == 0);
            bool hasASeven = evenNumbers.Contains(7);

            //assert
            areAllEvenNumbers.Should().BeTrue();
            containsMultipleOfThree.Should().BeTrue();
            hasASeven.Should().BeFalse();
        }

        [Test]
        public void ShouldEvaluateBookAgainstBookValidationRules()
        {
            //arrange
            Book mobyDick = new Book()
            {
                Author = "Herman Melville",
                Name = "Moby Dick"
            };

            var bookValidationRules = new List<Func<Book, bool>>()
            {
                b => !string.IsNullOrWhiteSpace(b.Name),
                b => !string.IsNullOrWhiteSpace(b.Author)
            };

            //act
            bool isBookValid = bookValidationRules.All(rule => rule(mobyDick));
        }
    }
}
