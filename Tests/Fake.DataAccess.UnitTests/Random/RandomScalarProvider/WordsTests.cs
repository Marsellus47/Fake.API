using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class WordsTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<string> values = SUT.Words(TestingSetSize);

            // Assert
            values.Should().HaveCount(TestingSetSize);
        }

        [Fact]
        public void ShouldReturnNotEmptyString()
        {
            // Act
            IEnumerable<string> values = SUT.Words(TestingSetSize);

            // Assert
            values.Should().OnlyContain(value => !string.IsNullOrEmpty(value));
        }

        [Fact]
        public void ShouldReturnOnlyLetters()
        {
            // Act
            IEnumerable<string> values = SUT.Words(TestingSetSize);

            // Assert
            values.Should().OnlyContain(value => value.ToCharArray().All(@char => char.IsLetter(@char)));
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<string> values = SUT.Words(count);

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
            IEnumerable<string> values = SUT.Words(boundaryValue);

            // Assert
            values.Should().HaveCount(expectedCount);
        }
    }
}