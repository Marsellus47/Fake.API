﻿using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class OddsTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<long> values = SUT.Odds(TestingSetSize);

            // Assert
            values.Should().HaveCount(TestingSetSize);
        }

        [Fact]
        public void ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const long minValue = long.MinValue;
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = SUT.Odds(TestingSetSize);

            // Assert
            values.Should().OnlyContain(value => !IsEven(value));
            values.Should().OnlyContain(value => value >= minValue && value <= maxValue);
        }

        [Fact]
        public void ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = SUT.Odds(TestingSetSize, min: minValue);

            // Assert
            values.Should().OnlyContain(value => !IsEven(value));
            values.Should().OnlyContain(value => value >= minValue);
        }

        [Fact]
        public void ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = SUT.Odds(TestingSetSize, max: maxValue);

            // Assert
            values.Should().OnlyContain(value => !IsEven(value));
            values.Should().OnlyContain(value => value <= maxValue);
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<long> values = SUT.Odds(count);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForInvertedMinMax()
        {
            // Arrange
            const long minValue = long.MaxValue;
            const long maxValue = long.MinValue;

            // Act
            IEnumerable<long> values = SUT.Odds(TestingSetSize, min: minValue, max: maxValue);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Fact]
        public void ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const long minValue = long.MinValue + 1;    // long.MinValue is even number so it cannot be picked

            // Act
            IEnumerable<long> values = SUT.Odds(TestingSetSize, min: minValue, max: minValue + 1);

            // Assert
            values.Should().Contain(minValue);
        }

        [Fact]
        public void ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = SUT.Odds(TestingSetSize, min: maxValue - 1, max: maxValue);

            // Assert
            values.Should().Contain(maxValue);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<long> values = SUT.Odds(boundaryValue);

            // Assert
            values.Should().HaveCount(boundaryValue);
        }
    }
}