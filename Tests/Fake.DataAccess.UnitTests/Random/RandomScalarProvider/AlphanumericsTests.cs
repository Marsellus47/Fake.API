using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class AlphanumericsTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(TestingSetSize);

            // Assert
            values.Should().HaveCount(TestingSetSize);
        }

        [Fact]
        public void ShouldReturnBetweenDefaultMinAndMaxLength()
        {
            // Arrange
            const short minValue = 0;
            const short maxValue = short.MaxValue;

            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(TestingSetSize);

            // Assert
            values.Should().OnlyContain(value => value.Length >= minValue && value.Length <= maxValue);
        }

        [Fact]
        public void ShouldReturnHigherThanMinLength()
        {
            // Arrange
            short minValue = (short)RandomNumber(0, short.MaxValue);

            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(TestingSetSize, minLength: minValue);

            // Assert
            values.Should().OnlyContain(value => value.Length >= minValue);
        }

        [Fact]
        public void ShouldReturnLowerThanMaxLength()
        {
            // Arrange
            short maxValue = (short)RandomNumber(0, short.MaxValue);

            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(TestingSetSize, maxLength: maxValue);

            // Assert
            values.Should().OnlyContain(value => value.Length <= maxValue);
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForInvertedMinMax()
        {
            // Arrange
            const short minValue = short.MaxValue;
            const short maxValue = 0;

            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(TestingSetSize, minLength: minValue, maxLength: maxValue);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(count);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Theory]
        [InlineData(0)]
        public void ShouldWorkForMinLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(TestingSetSize, minLength: boundaryValue, maxLength: (short)(boundaryValue + 1));

            // Assert
            values.Should().Contain(value => value.Length >= boundaryValue);
        }

        [Theory]
        [InlineData(short.MaxValue)]
        public void AlphaNumerics_ShouldWorkForMaxLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(TestingSetSize, minLength: (short)(boundaryValue - 1), maxLength: boundaryValue);

            // Assert
            values.Should().Contain(value => value.Length >= boundaryValue);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(boundaryValue);

            // Assert
            values.Should().HaveCount(boundaryValue);
        }
    }
}