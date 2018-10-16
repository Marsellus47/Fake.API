using Fake.Common.Extensions;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class DecimalTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const double minValue = double.MinValue;
            const double maxValue = double.MaxValue;

            // Act
            IEnumerable<double> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Decimal());

            // Assert
            values.Should().OnlyContain(value => value >= minValue && value <= maxValue);
        }

        [Fact]
        public void ShouldReturnlHigherThanMin()
        {
            // Arrange
            var rand = new System.Random();
            double minValue = rand.NextDouble(double.MinValue, double.MaxValue);

            // Act
            IEnumerable<double> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Decimal(min: minValue));

            // Assert
            values.Should().OnlyContain(value => value >= minValue);
        }

        [Fact]
        public void ShouldReturnLowerThanMax()
        {
            // Arrange
            var rand = new System.Random();
            double maxValue = rand.NextDouble(double.MinValue, double.MaxValue);

            // Act
            IEnumerable<double> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Decimal(max: maxValue));

            // Assert
            values.Should().OnlyContain(value => value <= maxValue);
        }

        [Fact]
        public void ShouldFailForInvertedMinMax()
        {
            // Arrange
            const double minValue = double.MaxValue;
            const double maxValue = double.MinValue;

            // Act
            Action value = () => SUT.Decimal(min: minValue, max: maxValue);

            // Assert
            value.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const double minValue = double.MinValue;

            // Act
            IEnumerable<double> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Decimal(min: minValue, max: minValue + 1));

            // Assert
            values.Should().Contain(minValue);
        }

        [Fact]
        public void ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const double maxValue = double.MaxValue;

            // Act
            IEnumerable<double> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Decimal(min: maxValue - 1, max: maxValue));

            // Assert
            values.Should().Contain(maxValue);
        }
    }
}