using GraphQL.Common.Response;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class RandomTestsBase : GraphQLTestsBase
    {
        protected override sealed string BuildQuery(string subQuery)
        {
            return base.BuildQuery($" random {{ {subQuery} }} ");
        }

        internal static RandomDTO GetRandom(GraphQLResponse response)
            => response.GetDataFieldAs<RandomDTO>("random");
    }
}
