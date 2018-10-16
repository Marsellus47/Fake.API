using Fake.Common.Extensions;
using System;

namespace Fake.DataAccess.UnitTests.Random.RandomScalarProvider
{
    public abstract class RandomScalarProviderTestsBase
    {
        protected const short TestingSetSize = 1000;
        protected readonly DataAccess.Random.RandomScalarProvider SUT = new DataAccess.Random.RandomScalarProvider();
        protected readonly Func<long, bool> IsEven = number => number % 2 == 0;
        protected readonly Func<long, long, long> RandomNumber = (min, max) => new System.Random().NextLong(min, max);
    }
}
