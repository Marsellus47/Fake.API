﻿using GraphQL.Common.Response;

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
    }
}
