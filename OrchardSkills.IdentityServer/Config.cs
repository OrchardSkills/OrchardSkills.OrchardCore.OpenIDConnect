// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),

                // let's include the role claim in the profile
                new ProfileWithRoleIdentityResource(),
                new IdentityResources.Email()
            };


        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                // the api requires the role claim
                new ApiResource("weatherapi", "The Weather API", new[] { JwtClaimTypes.Role })
            };


        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "client_id",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedCorsOrigins = { "https://localhost:44310" },
                    AllowedScopes = { "openid", "profile", "email", "weatherapi" },
                    RedirectUris = { "https://localhost:44310/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:44310" },
                    Enabled = true
                },
            };
    }
}