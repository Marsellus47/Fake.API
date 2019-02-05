using System;
using System.Reactive.Subjects;
using Fake.DataAccess.Interfaces.Random;
using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Server.Transports.Subscriptions.Abstractions;
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
                Name = "integer",
                Type = typeof(IntGraphType),
                Resolver = new FuncFieldResolver<long>(ResolveInt),
                Subscriber = new EventStreamResolver<long>(Subscribe)
            });
        }

        private long ResolveInt(ResolveFieldContext context)
            => (long)context.Source;

        private IObservable<long> Subscribe(ResolveEventStreamContext context)
        {
            var messageContext = context.UserContext.As<MessageHandlingContext>();

            var stream = new ReplaySubject<long>();
            stream.OnNext(_randomScalarProvider.Integer());
            stream.OnNext(_randomScalarProvider.Integer());
            stream.OnNext(_randomScalarProvider.Integer());

            return stream;
        }
    }
}
