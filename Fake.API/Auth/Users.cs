using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Test;

namespace Fake.API.Auth
{
    internal class Users
    {
        public static List<TestUser> Get()
            => new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "98e2d1ed-1d67-480c-b5c7-af3de3dadde7",
                    Username = "scott",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "scott@scottbrady91.com"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
                }
            };
    }
}
