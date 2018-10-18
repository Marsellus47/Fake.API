using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class HashesTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<string> values = SUT.Hashes(TestingSetSize);

            // Assert
            values.Should().HaveCount(TestingSetSize);
        }

        [Fact]
        public void ShouldReturnDefaultLength()
        {
            // Arrange
            const short length = 40;

            // Act
            IEnumerable<string> values = SUT.Hashes(TestingSetSize);

            // Assert
            values.Should().OnlyContain(value => value.Length == length);
        }

        [Fact]
        public void ShouldReturnDigitOrDefaultLowercase()
        {
            // Act
            IEnumerable<string> values = SUT.Hashes(1, TestingSetSize);

            // Assert
            values.First().ToCharArray().Should().OnlyContain(@char => char.IsDigit(@char) || char.IsLower(@char));
        }

        [Fact]
        public void ShouldReturnDigitOrLowercase()
        {
            // Arrange
            const bool uppercase = false;

            // Act
            IEnumerable<string> values = SUT.Hashes(1, TestingSetSize, upperCase: uppercase);

            // Assert
            values.First().ToCharArray().Should().OnlyContain(@char => char.IsDigit(@char) || char.IsLower(@char));
        }

        [Fact]
        public void ShouldReturnDigitOrUppercase()
        {
            // Arrange
            const bool uppercase = true;

            // Act
            IEnumerable<string> values = SUT.Hashes(1, TestingSetSize, upperCase: uppercase);

            // Assert
            values.First().ToCharArray().Should().OnlyContain(@char => char.IsDigit(@char) || char.IsUpper(@char));
        }

        [Fact]
        public void ShouldReturnCorrectLength()
        {
            // Arrange
            short length = (short)RandomNumber(1, short.MaxValue);

            // Act
            IEnumerable<string> values = SUT.Hashes(TestingSetSize, length);

            // Assert
            values.Should().OnlyContain(value => value.Length >= length);
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForNegativeLength()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<string> values = SUT.Hashes(count);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void ShouldWorkForLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            string value = SUT.Hashes(1, boundaryValue).First();

            // Assert
            value.Should().HaveLength(boundaryValue);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = SUT.Hashes(boundaryValue);

            // Assert
            values.Should().HaveCount(boundaryValue);
        }
    }
}