using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class DigitTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const byte minValue = 0;
            const byte maxValue = 9;

            // Act
            IEnumerable<byte> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Digit());

            // Assert
            values.Should().OnlyContain(value => value >= minValue && value <= maxValue);
        }

        [Fact]
        public void ShouldReturnHigherThanMin()
        {
            // Arrange
            byte minValue = (byte)RandomNumber(0, 9);

            // Act
            IEnumerable<byte> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Digit(min: minValue));

            // Assert
            values.Should().OnlyContain(value => value >= minValue);
        }

        [Fact]
        public void ShouldReturnLowerThanMax()
        {
            // Arrange
            byte maxValue = (byte)RandomNumber(0, 9);

            // Act
            IEnumerable<byte> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Digit(max: maxValue));

            // Assert
            values.Should().OnlyContain(value => value <= maxValue);
        }

        [Fact]
        public void ShouldFailForMaxHigherThan9()
        {
            // Arrange
            const byte maxValue = 10;

            // Act
            Action value = () => SUT.Digit(max: maxValue);

            // Assert
            value.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ShouldFailForInvertedMinMax()
        {
            // Arrange
            const byte minValue = 9;
            const byte maxValue = 0;

            // Act
            Action value = () => SUT.Digit(min: minValue, max: maxValue);

            // Assert
            value.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const byte minValue = byte.MinValue;

            // Act
            IEnumerable<byte> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Digit(min: minValue, max: minValue + 1));

            // Assert
            values.Should().Contain(minValue);
        }

        [Fact]
        public void ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const byte maxValue = 9;

            // Act
            IEnumerable<byte> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Digit(min: maxValue - 1, max: maxValue));

            // Assert
            values.Should().Contain(maxValue);
        }
    }
}