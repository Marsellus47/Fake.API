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
    public class ProvinceInputGroupGraphType : ObjectGraphType
    {
        public ProvinceInputGroupGraphType(IProvinceRepository provinceRepository)
        {
            FieldAsync<NonNullGraphType<ProvinceType>>(
                "insert",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProvinceInsertInputType>> { Name = "province" }),
                resolve: async (context) =>
                {
                    var province = context.GetArgument<Province>("province");
                    await provinceRepository.InsertAsync(province);
                    return province;
                });

            FieldAsync<ProvinceType>(
                "update",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProvinceUpdateInputType>> { Name = "province" }),
                resolve: async (context) =>
                {
                    var province = context.GetArgument<Province>("province");
                    await provinceRepository.UpdateAsync(province);
                    return province;
                });

            FieldAsync<ProvinceType>(
                "partialUpdate",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProvincePartialUpdateInputType>> { Name = "province" }),
                resolve: async (context) =>
                {
                    var values = context.Arguments["province"] as IDictionary<string, object>;

                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Province.Name));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Province.Code));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Province.StateId));

                    if (context.Errors.Any())
                        return null;

                    return await provinceRepository.PartiallyUpdateAsync(values);
                });

            FieldAsync<NonNullGraphType<BooleanGraphType>>(
                "delete",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = nameof(Province.Id).Camelize() }),
                resolve: async (context) =>
                {
                    var id = context.GetArgument<int>(nameof(Province.Id).Camelize());
                    return await provinceRepository.DeleteAsync(id);
                });
        }
    }
}
