using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using IdentityServer4;
using Newtonsoft.Json;

namespace WaterService.API
{
    public static class IdentityExtension
    {
        public static Model.Oauth.Userinfo GetCurrentUser(this IIdentity sender)
        {
#if Release

            return JsonConvert.DeserializeObject<Model.Oauth.Userinfo>(sender.ClaimToList().Find(p => p.Type == IdentityServerConstants.StandardScopes.Profile).Value);
#endif
            return new Model.Oauth.Userinfo() { UserName = "admin" };


        }
        private static List<Claim> ClaimToList(this IIdentity sender)
        {
            return ((ClaimsIdentity)sender).Claims.ToList();
        }
    }
}
