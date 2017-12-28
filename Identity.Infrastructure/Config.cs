using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Models;

namespace Identity.Infrastructure
{
    public static class Config
    {

        public static IEnumerable<ApiResource> GetAPIResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1","API 1")
            };
        }


        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="client",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes=
                    {
                        "api1"
                    }
                }
            };
        }
    }
}
