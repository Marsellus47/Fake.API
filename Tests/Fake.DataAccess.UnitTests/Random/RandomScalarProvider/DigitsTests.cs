using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class DigitsTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<byte> values = SUT.Digits(TestingSetSize);

            // Assert
            values.Should().HaveCount(TestingSetSize);
        }

        [Fact]
        public void ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const byte minValue = 0;
            const byte maxValue = 9;

            // Act
            IEnumerable<byte> values = SUT.Digits(TestingSetSize);

            // Assert
            values.Should().OnlyContain(value => value >= minValue && value <= maxValue);
        }

        [Fact]
        public void ShouldReturnHigherThanMin()
        {
            // Arrange
            byte minValue = (byte)RandomNumber(0, 9);

            // Act
            IEnumerable<byte> values = SUT.Digits(TestingSetSize, min: minValue);

            // Assert
            values.Should().OnlyContain(value => value >= minValue);
        }

        [Fact]
        public void ShouldReturnLowerThanMax()
        {
            // Arrange
            byte maxValue = (byte)RandomNumber(0, 9);

            // Act
            IEnumerable<byte> values = SUT.Digits(TestingSetSize, max: maxValue);

            // Assert
            values.Should().OnlyContain(value => value <= maxValue);
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<byte> values = SUT.Digits(count);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForInvertedMinMax()
        {
            // Arrange
            const byte minValue = 9;
            const byte maxValue = 0;

            // Act
            IEnumerable<long> values = SUT.Integers(TestingSetSize, min: minValue, max: maxValue);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Fact]
        public void ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const byte minValue = byte.MinValue;

            // Act
            IEnumerable<byte> values = SUT.Digits(TestingSetSize, min: minValue, max: minValue + 1);

            // Assert
            values.Should().Contain(minValue);
        }

        [Fact]
        public void ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const byte maxValue = 9;

            // Act
            IEnumerable<byte> values = SUT.Digits(TestingSetSize, min: maxValue - 1, max: maxValue);

            // Assert
            values.Should().Contain(maxValue);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<byte> values = SUT.Digits(boundaryValue);

            // Assert
            values.Should().HaveCount(boundaryValue);
        }
    }
}