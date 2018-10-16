using FluentAssertions;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class HexadecimalsTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnValidHexadecimal()
        {
            // Arrange
            long number;

            // Act
            IEnumerable<string> values = SUT.Hexadecimals(TestingSetSize);

            // Assert
            values.Should().OnlyContain(value => long.TryParse(value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out number));
        }

        [Fact]
        public void ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const long minValue = long.MinValue;
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = SUT.Hexadecimals(TestingSetSize).Select(value => Convert.ToInt64(value, 16));

            // Assert
            values.Should().OnlyContain(value => value >= minValue && value <= maxValue);
        }

        [Fact]
        public void ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = SUT.Hexadecimals(TestingSetSize, min: minValue).Select(value => Convert.ToInt64(value, 16));

            // Assert
            values.Should().OnlyContain(value => value >= minValue);
        }

        [Fact]
        public void ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = SUT.Hexadecimals(TestingSetSize, max: maxValue).Select(value => Convert.ToInt64(value, 16));

            // Assert
            values.Should().OnlyContain(value => value <= maxValue);
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationInvertedMinMax()
        {
            // Arrange
            const long minValue = long.MaxValue;
            const long maxValue = long.MinValue;

            // Act
            IEnumerable<string> values = SUT.Hexadecimals(TestingSetSize, min: minValue, max: maxValue);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Fact]
        public void ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const long minValue = long.MinValue;

            // Act
            IEnumerable<long> values = SUT.Hexadecimals(TestingSetSize, min: minValue, max: minValue + 1)
                .Select(value => Convert.ToInt64(value, 16));

            // Assert
            values.Should().Contain(minValue);
        }

        [Fact]
        public void ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = SUT.Hexadecimals(TestingSetSize, min: maxValue - 1, max: maxValue)
                .Select(value => Convert.ToInt64(value, 16));

            // Assert
            values.Should().Contain(maxValue);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = SUT.Hexadecimals(boundaryValue);

            // Assert
            values.Should().HaveCount(boundaryValue);
        }
    }
}