using Fake.API.GraphQL.Helpers;
using Fake.API.GraphQL.Types.CountryData.Output;
using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.Types;
using Humanizer;
using System.Collections.Generic;
using System.Linq;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CommunityInputGroupGraphType : ObjectGraphType
    {
        public CommunityInputGroupGraphType(ICommunityRepository communityRepository)
        {
            FieldAsync<NonNullGraphType<CommunityType>>(
                "insert",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CommunityInsertInputType>> { Name = "community" }),
                resolve: async (context) =>
                {
                    var community = context.GetArgument<Community>("community");
                    await communityRepository.InsertAsync(community);
                    return community;
                });

            FieldAsync<CommunityType>(
                "update",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CommunityUpdateInputType>> { Name = "community" }),
                resolve: async (context) =>
                {
                    var community = context.GetArgument<Community>("community");
                    await communityRepository.UpdateAsync(community);
                    return community;
                });

            FieldAsync<CommunityType>(
                "partialUpdate",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CommunityPartialUpdateInputType>> { Name = "community" }),
                resolve: async (context) =>
                {
                    var values = context.Arguments["community"] as IDictionary<string, object>;

                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Community.Name));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Community.Code));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Community.ProvinceId));

                    if (context.Errors.Any())
                        return null;

                    return await communityRepository.PartiallyUpdateAsync(values);
                });

            FieldAsync<NonNullGraphType<BooleanGraphType>>(
                "delete",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = nameof(Community.Id).Camelize() }),
                resolve: async (context) =>
                {
                    var id = context.GetArgument<int>(nameof(Community.Id).Camelize());
                    return await communityRepository.DeleteAsync(id);
                });
        }
    }
}
