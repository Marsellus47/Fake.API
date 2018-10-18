using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class CharTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const char minValue = char.MinValue;
            const char maxValue = char.MaxValue;

            // Act
            IEnumerable<char> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Char());

            // Assert
            values.Should().OnlyContain(value => value >= minValue && value <= maxValue);
        }

        [Fact]
        public void ShouldReturnHigherThanMin()
        {
            // Arrange
            char minValue = (char)RandomNumber(char.MinValue, char.MaxValue);

            // Act
            IEnumerable<char> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Char(min: minValue));

            // Assert
            values.Should().OnlyContain(value => value >= minValue);
        }

        [Fact]
        public void ShouldReturnLowerThanMax()
        {
            // Arrange
            char maxValue = (char)RandomNumber(char.MinValue, char.MaxValue);

            // Act
            IEnumerable<char> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Char(max: maxValue));

            // Assert
            values.Should().OnlyContain(value => value <= maxValue);
        }

        [Fact]
        public void ShouldFailForInvertedMinMax()
        {
            // Arrange
            const char minValue = char.MaxValue;
            const char maxValue = char.MinValue;

            // Act
            Action value = () => SUT.Char(min: minValue, max: maxValue);

            // Assert
            value.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const char minValue = char.MinValue;

            // Act
            IEnumerable<char> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Char(min: minValue, max: (char)(minValue + 1)));

            // Assert
            values.Should().Contain(minValue);
        }

        [Fact]
        public void ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const char maxValue = char.MaxValue;

            // Act
            IEnumerable<char> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Char(min: (char)(maxValue - 1), max: maxValue));

            // Assert
            values.Should().Contain(maxValue);
        }
    }
}