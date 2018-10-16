using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class StringTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnBetweenDefaultMinAndMaxLength()
        {
            // Arrange
            const short minValue = 0;
            const short maxValue = short.MaxValue;

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.String());

            // Assert
            values.Should().OnlyContain(value => value.Length >= minValue && value.Length <= maxValue);
        }

        [Fact]
        public void ShouldReturnBetweenDefaultMinAndMaxChar()
        {
            // Arrange
            const char minValue = char.MinValue;
            const char maxValue = char.MaxValue;

            // Act
            string value = SUT.String(minLength: TestingSetSize, maxLength: TestingSetSize);

            // Assert
            value.ToCharArray().Should().OnlyContain(@char => @char >= minValue && @char <= maxValue);
        }

        [Fact]
        public void ShouldReturnHigherThanMinLength()
        {
            // Arrange
            short minValue = (short)RandomNumber(1, short.MaxValue);

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.String(minLength: minValue));

            // Assert
            values.Should().OnlyContain(value => value.Length >= minValue);
        }

        [Fact]
        public void ShouldReturnLowerThanMaxLength()
        {
            // Arrange
            short maxValue = (short)RandomNumber(1, short.MaxValue);

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.String(maxLength: maxValue));

            // Assert
            values.Should().OnlyContain(value => value.Length <= maxValue);
        }

        [Fact]
        public void ShouldReturnHigherThanMinChar()
        {
            // Arrange
            char minValue = (char)RandomNumber(1, char.MaxValue);

            // Act
            string value = SUT.String(minLength: TestingSetSize, maxLength: TestingSetSize, minChar: minValue);

            // Assert
            value.ToCharArray().Should().OnlyContain(@char => @char >= minValue);
        }

        [Fact]
        public void ShouldReturnLowerThanMaxChar()
        {
            // Arrange
            char maxValue = (char)RandomNumber(1, char.MaxValue);

            // Act
            string value = SUT.String(minLength: TestingSetSize, maxLength: TestingSetSize, maxChar: maxValue);

            // Assert
            value.ToCharArray().Should().OnlyContain(@char => @char <= maxValue);
        }

        [Fact]
        public void ShouldReturnZeroLength()
        {
            // Arrange
            const short length = 0;

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.String(minLength: length, maxLength: length));

            // Assert
            values.Should().OnlyContain(value => string.IsNullOrEmpty(value));
        }

        [Fact]
        public void ShouldFailForInvertedMinMaxLength()
        {
            // Arrange
            const short minValue = short.MaxValue;
            const short maxValue = 1;

            // Act
            Action value = () => SUT.String(minLength: minValue, maxLength: maxValue);

            // Assert
            value.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ShouldFailForInvertedMinMaxChar()
        {
            // Arrange
            const char minValue = char.MaxValue;
            const char maxValue = char.MinValue;

            // Act
            Action value = () => SUT.String(minChar: minValue, maxChar: maxValue);

            // Assert
            value.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ShouldFailForNegativeLength()
        {
            // Arrange
            short minValue = (short)RandomNumber(short.MinValue, -1);

            // Act
            Action value = () => SUT.String(minLength: minValue);

            // Assert
            value.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(0)]
        public void ShouldWorkForMinLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.String(minLength: boundaryValue, maxLength: (short)(boundaryValue + 1)));

            // Assert
            values.Should().Contain(value => value.Length >= boundaryValue);
        }

        [Theory]
        [InlineData(short.MaxValue)]
        public void ShouldWorkForMaxLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.String(minLength: (short)(boundaryValue - 1), maxLength: boundaryValue));

            // Assert
            values.Should().Contain(value => value.Length >= boundaryValue);
        }

        [Fact]
        public void ShouldWorkForMinCharBoundaryCondition()
        {
            // Arrange
            const char minValue = char.MinValue;

            // Act
            IEnumerable<char> values = SUT.String(TestingSetSize, TestingSetSize, minChar: minValue, maxChar: (char)(minValue + 1)).ToCharArray();

            // Assert
            values.Should().Contain(minValue);
        }

        [Fact]
        public void ShouldWorkForMaxCharBoundaryCondition()
        {
            // Arrange
            const char maxValue = char.MaxValue;

            // Act
            IEnumerable<char> values = SUT.String(TestingSetSize, TestingSetSize, minChar: (char)(maxValue - 1), maxChar: maxValue).ToCharArray();

            // Assert
            values.Should().Contain(maxValue);
        }
    }
}