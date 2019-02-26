using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;
using Fake.API.GraphQL.Types.Random.Output;
using Fake.DataAccess.Interfaces.Random;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;

namespace Fake.API.GraphQL.Infrastructure
{
    public class FakeApiSubscription : ObjectGraphType
    {
        private readonly IRandomScalarProvider _randomScalarProvider;

        public FakeApiSubscription(IRandomScalarProvider randomScalarProvider)
        {
            _randomScalarProvider = randomScalarProvider;

            AddField(new EventStreamFieldType
            {
                Name = "random",
                Type = typeof(RandomType),
                Resolver = new FuncFieldResolver<RandomData>(Resolve),
                Subscriber = new EventStreamResolver<RandomData>(Subscribe)
            });
        }

        private static RandomData Resolve(ResolveFieldContext context)
            => (RandomData)context.Source;

        private IObservable<RandomData> Subscribe(ResolveEventStreamContext context)
        {
            return GetRandomData().ToObservable();
        }

        private IEnumerable<RandomData> GetRandomData()
        {
            // Warning Endless loop while main thread is still running
            while(true)
            {
                Thread.Sleep((int)_randomScalarProvider.Integer(500, 2000));
                yield return new RandomData();
            }
        }
    }
}
