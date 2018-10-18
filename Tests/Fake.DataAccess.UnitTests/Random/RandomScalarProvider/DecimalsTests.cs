using Fake.Common.Extensions;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class DecimalsTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<double> values = SUT.Decimals(TestingSetSize);

            // Assert
            values.Should().HaveCount(TestingSetSize);
        }

        [Fact]
        public void ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const double minValue = double.MinValue;
            const double maxValue = double.MaxValue;

            // Act
            IEnumerable<double> values = SUT.Decimals(TestingSetSize);

            // Assert
            values.Should().OnlyContain(value => value >= minValue && value <= maxValue);
        }

        [Fact]
        public void ShouldReturnHigherThanMin()
        {
            // Arrange
            var rand = new System.Random();
            double minValue = rand.NextDouble(double.MinValue, double.MaxValue);

            // Act
            IEnumerable<double> values = SUT.Decimals(TestingSetSize, min: minValue);

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
            IEnumerable<double> values = SUT.Decimals(TestingSetSize, max: maxValue);

            // Assert
            values.Should().OnlyContain(value => value <= maxValue);
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<double> values = SUT.Decimals(count);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForInvertedMinMax()
        {
            // Arrange
            const double minValue = double.MaxValue;
            const double maxValue = double.MinValue;

            // Act
            IEnumerable<double> values = SUT.Decimals(TestingSetSize, min: minValue, max: maxValue);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Fact]
        public void ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const double minValue = double.MinValue;

            // Act
            IEnumerable<double> values = SUT.Decimals(TestingSetSize, min: minValue, max: minValue + 1);

            // Assert
            values.Should().Contain(minValue);
        }

        [Fact]
        public void ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const double maxValue = double.MaxValue;

            // Act
            IEnumerable<double> values = SUT.Decimals(TestingSetSize, min: maxValue - 1, max: maxValue);

            // Assert
            values.Should().Contain(maxValue);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<double> values = SUT.Decimals(boundaryValue);

            // Assert
            values.Should().HaveCount(boundaryValue);
        }
    }
}