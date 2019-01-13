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
    public class PlaceInputGroupGraphType : ObjectGraphType
    {
        public PlaceInputGroupGraphType(IPlaceRepository placeRepository)
        {
            FieldAsync<NonNullGraphType<PlaceType>>(
                "insert",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PlaceInsertInputType>> { Name = "place" }),
                resolve: async (context) =>
                {
                    var place = context.GetArgument<Place>("place");
                    await placeRepository.InsertAsync(place);
                    return place;
                });

            FieldAsync<PlaceType>(
                "update",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PlaceUpdateInputType>> { Name = "place" }),
                resolve: async (context) =>
                {
                    var place = context.GetArgument<Place>("place");
                    await placeRepository.UpdateAsync(place);
                    return place;
                });

            FieldAsync<PlaceType>(
                "partialUpdate",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PlacePartialUpdateInputType>> { Name = "place" }),
                resolve: async (context) =>
                {
                    var values = context.Arguments["place"] as IDictionary<string, object>;

                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Place.Name));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Place.PostCode));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Place.LatLong));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Place.CommunityId));

                    if (context.Errors.Any())
                        return null;

                    return await placeRepository.PartiallyUpdateAsync(values);
                });

            FieldAsync<NonNullGraphType<BooleanGraphType>>(
                "delete",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = nameof(Place.Id).Camelize() }),
                resolve: async (context) =>
                {
                    var id = context.GetArgument<int>(nameof(Place.Id).Camelize());
                    return await placeRepository.DeleteAsync(id);
                });
        }
    }
}
