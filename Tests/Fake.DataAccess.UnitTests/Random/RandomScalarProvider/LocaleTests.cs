using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public class LocaleTests : RandomScalarProviderTestsBase
    {
        [Fact]
        public void ShouldReturnNotEmptyString()
        {
            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Locale());

            // Assert
            values.Should().OnlyContain(value => !string.IsNullOrEmpty(value));
        }
    }
}