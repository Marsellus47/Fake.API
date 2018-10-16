using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class BooleansTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<bool> values = SUT.Booleans(TestingSetSize);

            // Assert
            values.Should().HaveCount(TestingSetSize);
        }

        [Fact]
        public void ShouldReturnRandomValues()
        {
            // Act
            IEnumerable<bool> values = SUT.Booleans(TestingSetSize);

            // Assert
            values.Should().Contain(value => value);
            values.Should().Contain(value => value);
        }

        [Fact]
        public void ShouldReturnMoreTruesForHigherWeight()
        {
            // Arrange
            const float weight = 0.8F;

            // Act
            IEnumerable<bool> values = SUT.Booleans(TestingSetSize, weight);

            // Assert
            values.Count(value => value).Should().BeCloseTo(TestingSetSize, TestingSetSize / 3);
        }

        [Fact]
        public void ShouldReturnAllTruesForWeight1()
        {
            // Arrange
            const float weight = 1F;

            // Act
            IEnumerable<bool> values = SUT.Booleans(TestingSetSize, weight);

            // Assert
            values.Should().OnlyContain(value => value);
        }

        [Fact]
        public void ShouldReturnMoreFalsesForLowerWeight()
        {
            // Arrange
            const float weight = 0.2F;

            // Act
            IEnumerable<bool> values = SUT.Booleans(TestingSetSize, weight);

            // Assert
            values.Count(value => !value).Should().BeCloseTo(TestingSetSize, TestingSetSize / 3);
        }

        [Fact]
        public void ShouldReturnAllFalsesForWeight0()
        {
            // Arrange
            const float weight = 0F;

            // Act
            IEnumerable<bool> values = SUT.Booleans(TestingSetSize, weight);

            // Assert
            values.Should().OnlyContain(value => !value);
        }

        [Fact]
        public void ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<bool> values = SUT.Booleans(count);

            // Assert
            values.Should().NotBeNull();
            values.Should().BeEmpty();
        }

        [Theory]
        [InlineData(0F, 0, TestingSetSize)]
        [InlineData(1F, TestingSetSize, 0)]
        public void ShouldWorkForWeightBoundaryCondition(float boundaryValue, short numberOfTrues, short numberOfFalses)
        {
            // Act
            IEnumerable<bool> values = SUT.Booleans(TestingSetSize, boundaryValue);

            // Assert
            values.Count(value => value).Should().Be(numberOfTrues);
            values.Count(value => !value).Should().Be(numberOfFalses);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<bool> values = SUT.Booleans(boundaryValue);

            // Assert
            values.Should().HaveCount(boundaryValue);
        }
    }
}