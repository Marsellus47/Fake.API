using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class LocalesTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnNotEmptyString()
        {
            // Act
            IEnumerable<string> values = SUT.Locales(TestingSetSize);

            // Assert
            values.Should().OnlyContain(value => !string.IsNullOrEmpty(value));
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<string> values = SUT.Locales(count);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Theory]
        [InlineData(short.MinValue, 0)]
        [InlineData(-1, 0)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(short.MaxValue, short.MaxValue)]
        public void ShouldWorkForCountBoundaryCondition(short boundaryValue, short expectedCount)
        {
            // Act
            IEnumerable<string> values = SUT.Locales(boundaryValue);

            // Assert
            values.Should().HaveCount(expectedCount);
        }
    }
}