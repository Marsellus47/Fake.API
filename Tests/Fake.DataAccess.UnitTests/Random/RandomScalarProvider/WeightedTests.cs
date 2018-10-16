using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class WeightedTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnItemFromEnumeration()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, 5);
            float[] weights = { 0.1F, 0.6F, 0.1F, 0.1F, 0.1F };

            // Act
            IEnumerable<int> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Weighted(enumeration, weights));

            // Assert
            values.Should().OnlyContain(value => enumeration.Contains(value));
        }

        [Fact]
        public void ShouldReturnDefaultItemForNullEnumration()
        {
            // Arrange
            const IEnumerable<int> enumeration = null;
            const float[] weights = null;

            // Act
            IEnumerable<int> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Weighted(enumeration, weights));

            // Assert
            values.Should().OnlyContain(value => value == default(int));
        }

        [Fact]
        public void ShouldFailForDifferentCounts()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, 5);
            float[] weights = { 0.1F };

            // Act
            Action value = () => SUT.Weighted(enumeration, weights);

            // Assert
            value.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ShouldWorkForEmptyEnumration()
        {
            // Arrange
            IEnumerable<int> enumeration = new List<int>();
            float[] weights = { };

            // Act
            IEnumerable<int> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Weighted(enumeration, weights));

            // Assert
            values.Should().OnlyContain(value => value == default(int));
        }
    }
}