using GraphQL.Common.Response;
using System.Globalization;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class RandomTestsBase : GraphQLTestsBase<RandomDTO>
    {
        protected override sealed string BuildQuery(string subQuery)
        {
            return base.BuildQuery($" random {{ {subQuery} }} ");
        }

        protected override RandomDTO ParseResponse(GraphQLResponse response)
            => response.GetDataFieldAs<RandomDTO>("random");

        protected NumberFormatInfo DecimalNumberFormatInfo
            => new NumberFormatInfo { PercentDecimalSeparator = "." };
    }
}
