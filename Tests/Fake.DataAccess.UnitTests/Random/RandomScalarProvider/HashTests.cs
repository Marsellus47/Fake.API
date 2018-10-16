using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class HashTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnDefaultLength()
        {
            // Arrange
            const short length = 40;

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Hash());

            // Assert
            values.Should().OnlyContain(value => value.Length == length);
        }

        [Fact]
        public void ShouldReturnDigitOrDefaultLowercase()
        {
            // Act
            string value = SUT.Hash(TestingSetSize);

            // Assert
            value.ToCharArray().Should().OnlyContain(@char => char.IsDigit(@char) || char.IsLower(@char));
        }

        [Fact]
        public void ShouldReturnDigitOrLowercase()
        {
            // Arrange
            const bool uppercase = false;

            // Act
            string value = SUT.Hash(TestingSetSize, uppercase);

            // Assert
            value.ToCharArray().Should().OnlyContain(@char => char.IsDigit(@char) || char.IsLower(@char));
        }

        [Fact]
        public void ShouldReturnDigitOrUppercase()
        {
            // Arrange
            const bool uppercase = true;

            // Act
            string value = SUT.Hash(TestingSetSize, uppercase);

            // Assert
            value.ToCharArray().Should().OnlyContain(@char => char.IsDigit(@char) || char.IsUpper(@char));
        }

        [Fact]
        public void ShouldReturnCorrectLength()
        {
            // Arrange
            short length = (short)RandomNumber(1, short.MaxValue);

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Hash(length));

            // Assert
            values.Should().OnlyContain(value => value.Length >= length);
        }

        [Fact]
        public void ShouldFailForNegativeLength()
        {
            // Arrange
            short length = (short)RandomNumber(short.MinValue, 0);

            // Act
            Action value = () => SUT.Hash(length);

            // Assert
            value.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void ShouldWorkForLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            string value = SUT.Hash(boundaryValue);

            // Assert
            value.Should().HaveLength(boundaryValue);
        }
    }
}