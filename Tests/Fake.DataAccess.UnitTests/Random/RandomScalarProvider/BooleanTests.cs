using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class BooleanTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnRandomValues()
        {
            // Act
            IEnumerable<bool> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Boolean());

            // Assert
            values.Should().Contain(value => value);
            values.Should().Contain(value => !value);
        }

        [Fact]
        public void ShouldReturnMoreTruesForHigherWeight()
        {
            // Arrange
            const float weight = 0.8F;

            // Act
            IEnumerable<bool> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Boolean(weight));

            // Assert
            values.Count(value => value).Should().BeCloseTo(TestingSetSize, TestingSetSize / 3);
        }

        [Fact]
        public void ShouldReturnAllTruesForWeight1()
        {
            // Arrange
            const float weight = 1F;

            // Act
            IEnumerable<bool> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Boolean(weight));

            // Assert
            values.Should().OnlyContain(_ => true);
        }

        [Fact]
        public void ShouldReturnMoreFalsesForLowerWeight()
        {
            // Arrange
            const float weight = 0.2F;

            // Act
            IEnumerable<bool> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Boolean(weight));

            // Assert
            values.Count(value => !value).Should().BeCloseTo(TestingSetSize, TestingSetSize / 3);
        }

        [Fact]
        public void ShouldReturnAllFalsesForWeight0()
        {
            // Arrange
            const float weight = 0F;

            // Act
            IEnumerable<bool> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Boolean(weight));

            // Assert
            values.Should().OnlyContain(value => !value);
        }

        [Theory]
        [InlineData(0F, 0, TestingSetSize)]
        [InlineData(1F, TestingSetSize, 0)]
        public void ShouldWorkForWeightBoundaryCondition(float boundaryValue, short numberOfTrues, short numberOfFalses)
        {
            // Act
            IEnumerable<bool> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Boolean(boundaryValue));

            // Assert
            values.Count(value => value).Should().Be(numberOfTrues);
            values.Count(value => !value).Should().Be(numberOfFalses);
        }
    }
}