using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class AlphanumericTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnBetweenDefaultMinAndMaxLength()
        {
            // Arrange
            const short minValue = 0;
            const short maxValue = short.MaxValue;

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.AlphaNumeric());

            // Assert
            values.Should().OnlyContain(value => value.Length >= minValue && value.Length <= maxValue);
        }

        [Fact]
        public void ShouldReturnHigherThanMinLength()
        {
            // Arrange
            short minValue = (short)RandomNumber(0, short.MaxValue);

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.AlphaNumeric(minLength: minValue));

            // Assert
            values.Should().OnlyContain(value => value.Length >= minValue);
        }

        [Fact]
        public void ShouldReturnLowerThanMaxLength()
        {
            // Arrange
            short maxValue = (short)RandomNumber(0, short.MaxValue);

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.AlphaNumeric(maxLength: maxValue));

            // Assert
            values.Should().OnlyContain(value => value.Length <= maxValue);
        }

        [Fact]
        public void ShouldFailForInvertedMinMax()
        {
            // Arrange
            const short minValue = short.MaxValue;
            const short maxValue = 0;

            // Act
            Action value = () => SUT.AlphaNumeric(minLength: minValue, maxLength: maxValue);

            // Assert
            value.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ShouldFailForNegativeLength()
        {
            // Arrange
            short length = (short)RandomNumber(short.MinValue, -1);

            // Act
            Action value = () => SUT.AlphaNumeric(minLength: length);

            // Assert
            value.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(0)]
        public void ShouldWorkForMinLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize)
                .Select(_ => SUT.AlphaNumeric(minLength: boundaryValue, maxLength: (short)(boundaryValue + 1)));

            // Assert
            values.Should().Contain(value => value.Length >= boundaryValue);
        }

        [Theory]
        [InlineData(short.MaxValue)]
        public void ShouldWorkForMaxLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize)
                .Select(_ => SUT.AlphaNumeric(minLength: (short)(boundaryValue - 1), maxLength: boundaryValue));

            // Assert
            values.Should().Contain(value => value.Length >= boundaryValue);
        }
    }
}