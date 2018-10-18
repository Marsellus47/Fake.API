using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class EnumerationElementTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnItemFromEnumeration()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, TestingSetSize);

            // Act
            int value = SUT.EnumerationElement(enumeration);

            // Assert
            enumeration.Should().Contain(value);
        }

        [Fact]
        public void ShouldReturnDefaultItemForNullEnumeration()
        {
            // Arrange
            const IEnumerable<int> enumeration = null;

            // Act
            int value = SUT.EnumerationElement(enumeration);

            // Assert
            value.Should().Be(default(int));
        }

        [Fact]
        public void ShouldWorkForEnumerationLengthBoundaryCondition()
        {
            // Arrange
            IEnumerable<int> enumeration = new List<int>();

            // Act
            IEnumerable<int> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.EnumerationElement(enumeration));

            // Assert
            values.Should().OnlyContain(value => value == default(int));
        }
    }
}