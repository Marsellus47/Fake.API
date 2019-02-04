using System.Security.Claims;
using GraphQL.Authorization;

namespace Fake.API.GraphQL.Infrastructure
{
    public class UserContext : IProvideClaimsPrincipal
    {
        public ClaimsPrincipal User { get; set; }
    }
}
