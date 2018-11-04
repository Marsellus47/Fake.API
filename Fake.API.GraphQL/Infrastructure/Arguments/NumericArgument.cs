using GraphQL.Types;
using System.Collections.Generic;

namespace Fake.API.GraphQL.Infrastructure.Arguments
{
    public class NumericArgument : QueryArgument<IntGraphType>, IProvideMetadata
    {
        public IDictionary<string, object> Metadata { get; } = new Dictionary<string, object>();

        public TMetadata GetMetadata<TMetadata>(string key, TMetadata defaultValue = default(TMetadata))
            => HasMetadata(key) ? (TMetadata)Metadata[key] : defaultValue;

        public bool HasMetadata(string key)
            => Metadata.ContainsKey(key);

        public static string MinValueMetadataName => "MinValue";

        public static string MaxValueMetadataName => "MaxValue";
    }
}
