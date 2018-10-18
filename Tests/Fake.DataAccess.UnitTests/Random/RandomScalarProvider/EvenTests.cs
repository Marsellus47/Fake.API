using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class EvenTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const long minValue = long.MinValue;
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Even());

            // Assert
            values.Should().OnlyContain(value => IsEven(value));
            values.Should().OnlyContain(value => value >= minValue && value <= maxValue);
        }

        [Fact]
        public void ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Even(min: minValue));

            // Assert
            values.Should().OnlyContain(value => IsEven(value));
            values.Should().OnlyContain(value => value >= minValue);
        }

        [Fact]
        public void ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Even(max: maxValue));

            // Assert
            values.Should().OnlyContain(value => IsEven(value));
            values.Should().OnlyContain(value => value <= maxValue);
        }

        [Fact]
        public void ShouldFailForInvertedMinMax()
        {
            // Arrange
            const long minValue = long.MaxValue;
            const long maxValue = long.MinValue;

            // Act
            Action value = () => SUT.Even(min: minValue, max: maxValue);

            // Assert
            value.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const long minValue = long.MinValue;

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Even(min: minValue, max: minValue + 1));

            // Assert
            values.Should().Contain(minValue);
        }

        [Fact]
        public void ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const long maxValue = long.MaxValue - 1;    // long.MaxValue is odd number so it cannot be picked

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Even(min: maxValue - 1, max: maxValue));

            // Assert
            values.Should().Contain(maxValue);
        }
    }
}