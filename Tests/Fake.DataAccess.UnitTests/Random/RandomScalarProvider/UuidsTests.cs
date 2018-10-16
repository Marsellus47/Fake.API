using FluentAssertions;
using System.Collections.Generic;
using System;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class UuidsTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<Guid> values = SUT.Uuids(TestingSetSize);

            // Assert
            values.Should().HaveCount(TestingSetSize);
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<Guid> values = SUT.Uuids(count);

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
            IEnumerable<Guid> values = SUT.Uuids(boundaryValue);

            // Assert
            values.Should().HaveCount(expectedCount);
        }
    }
}