using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace OauthService
{
    public class InMemoryConfiguration
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[]
            {
                new ApiResource("socialnetwork", "社交网络")
                {
                    UserClaims = new [] { IdentityServerConstants.StandardScopes.Profile, "userInfo" }
                }
            };
        }
        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }
        public static IEnumerable<Client> Clients()
        {
            var list = new List<Client>();
            var cors = new List<string>();
            //for (int i = 2000; i <= 65535; i++)
            //{
            //    cors.Add(string.Format("http://127.0.0.1:{0}", i));
            //}
            cors.Add("http://127.0.0.1:8000");
            new BLL.ApplicationService().GetList().ForEach(item =>
            {
                var clent = new Client()
                {
                    ClientId = item.ApplicationId.ToString(),
                    ClientName = item.DisplayName,
                    ClientSecrets = new[] { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = new[] { "socialnetwork", IdentityServerConstants.StandardScopes.Profile },
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true,
                    AllowedCorsOrigins = cors
                };
                list.Add(clent);
            });
            return list.ToArray();
        }

        public static IEnumerable<TestUser> Users()
        {
            return new[]
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "mail@qq.com",
                    Password = "password"
                }
            };
        }
    }
}