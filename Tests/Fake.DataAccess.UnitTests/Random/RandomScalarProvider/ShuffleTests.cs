using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class ShuffleTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnSameNumberOfItems()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, TestingSetSize);

            // Act
            IEnumerable<int> values = SUT.Shuffle(enumeration);

            // Assert
            values.Should().HaveSameCount(enumeration);
        }

        [Fact]
        public void ShouldReturnShuffledEnumeration()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, TestingSetSize);

            // Act
            IEnumerable<int> values = SUT.Shuffle(enumeration);

            // Assert
            enumeration.SequenceEqual(values).Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForNullEnumration()
        {
            // Arrange
            const IEnumerable<int> enumeration = null;

            // Act
            IEnumerable<int> values = SUT.Shuffle(enumeration);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(short.MaxValue, false)]
        public void ShouldWorkForEnumerationLengthBoundaryCondition(short boundaryValue, bool expectedSameEnumeration)
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, boundaryValue);

            // Act
            IEnumerable<int> values = SUT.Shuffle(enumeration);

            // Assert
            if (expectedSameEnumeration)
            {
                values.Should().BeEquivalentTo(enumeration, options => options.WithStrictOrdering());
            }
            else
            {
                enumeration.SequenceEqual(values).Should().BeFalse();
            }
        }
    }
}