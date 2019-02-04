using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Test;

namespace Fake.API.IntegrationTests.Infrastructure.IdentityServer
{
    public class IdentityServerProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            await Task.Run(() =>
            {
                var subject = context.Subject;
                if(subject == null)
                {
                    throw new ArgumentNullException($"{nameof(ProfileDataRequestContext)}.{nameof(context.Subject)}");
                }

                var subClaim = subject.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject);
                if(subClaim == null)
                {
                    throw new ArgumentNullException($"{nameof(ProfileDataRequestContext)}.{nameof(context.Subject)}", "Subject doesn't contain claim 'Sub'");
                }

                TestUser user = IdentityServerSetup.GetUsers().FirstOrDefault(x => x.SubjectId == subClaim.Value);
                if(user != null)
                {
                    var claims = new List<Claim>();
                    user.Claims
                        .ToList()
                        .ForEach(claim => claims.Add(new Claim(claim.Type, claim.Value, claim.ValueType, claim.Issuer, claim.OriginalIssuer)));

                    context.IssuedClaims = claims;
                }
            });
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            await Task.Run(() => context.IsActive = true);
        }
    }
}
