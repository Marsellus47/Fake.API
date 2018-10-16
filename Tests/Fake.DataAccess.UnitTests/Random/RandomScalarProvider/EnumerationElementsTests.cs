using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class EnumerationElementsTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnCorrectCount()
        {
            // Arrange
            const short count = TestingSetSize / 10;
            IEnumerable<int> enumeration = Enumerable.Range(1, TestingSetSize);

            // Act
            IEnumerable<int> values = SUT.EnumerationElements(count, enumeration);

            // Assert
            values.Should().HaveCount(count);
        }

        [Fact]
        public void ShouldReturnItemFromEnumeration()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, TestingSetSize);

            // Act
            IEnumerable<int> values = SUT.EnumerationElements(TestingSetSize / 10, enumeration);

            // Assert
            values.Should().OnlyContain(value => enumeration.Contains(value));
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForNullEnumration()
        {
            // Arrange
            const IEnumerable<int> enumeration = null;

            // Act
            IEnumerable<int> values = SUT.EnumerationElements(TestingSetSize / 10, enumeration);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Fact]
        public void ShouldWorkForEnumerationLengthBoundaryCondition()
        {
            // Arrange
            IEnumerable<int> enumeration = new List<int>();

            // Act
            IEnumerable<int> values = SUT.EnumerationElements(0, enumeration);

            // Assert
            values.Should().BeEmpty();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, boundaryValue);

            // Act
            IEnumerable<int> values = SUT.EnumerationElements(boundaryValue, enumeration);

            // Assert
            values.Should().HaveCount(boundaryValue);
        }
    }
}