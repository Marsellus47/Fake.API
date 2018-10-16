using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class CharsTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<char> values = SUT.Chars(TestingSetSize);

            // Assert
            values.Should().HaveCount(TestingSetSize);
        }

        [Fact]
        public void ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const char minValue = char.MinValue;
            const char maxValue = char.MaxValue;

            // Act
            IEnumerable<char> values = SUT.Chars(TestingSetSize);

            // Assert
            values.Should().OnlyContain(value => value >= minValue && value <= maxValue);
        }

        [Fact]
        public void ShouldReturnHigherThanMin()
        {
            // Arrange
            char minValue = (char)RandomNumber(char.MinValue, char.MaxValue);

            // Act
            IEnumerable<char> values = SUT.Chars(TestingSetSize, min: minValue);

            // Assert
            values.Should().OnlyContain(value => value >= minValue);
        }

        [Fact]
        public void ShouldReturnLowerThanMax()
        {
            // Arrange
            char maxValue = (char)RandomNumber(char.MinValue, char.MaxValue);

            // Act
            IEnumerable<char> values = SUT.Chars(TestingSetSize, max: maxValue);

            // Assert
            values.Should().OnlyContain(value => value <= maxValue);
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<char> values = SUT.Chars(count);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForInvertedMinMax()
        {
            // Arrange
            const char minValue = char.MaxValue;
            const char maxValue = char.MinValue;

            // Act
            IEnumerable<char> values = SUT.Chars(TestingSetSize, min: minValue, max: maxValue);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Fact]
        public void ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const char minValue = char.MinValue;

            // Act
            IEnumerable<char> values = SUT.Chars(TestingSetSize, min: minValue, max: (char)(minValue + 1));

            // Assert
            values.Should().Contain(minValue);
        }

        [Fact]
        public void ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const char maxValue = char.MaxValue;

            // Act
            IEnumerable<char> values = SUT.Chars(TestingSetSize, min: (char)(maxValue - 1), max: maxValue);

            // Assert
            values.Should().Contain(maxValue);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<char> values = SUT.Chars(boundaryValue);

            // Assert
            values.Should().HaveCount(boundaryValue);
        }
    }
}