using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class WordTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnNotEmptyString()
        {
            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Word());

            // Assert
            values.Should().OnlyContain(value => !string.IsNullOrEmpty(value));
        }

        [Fact]
        public void ShouldReturnOnlyLetters()
        {
            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Word());

            // Assert
            values.Should().OnlyContain(value => value.ToCharArray().All(@char => char.IsLetter(@char)));
        }
    }
}