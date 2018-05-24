using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using BLL;
using IdentityServer4;
using Newtonsoft.Json;

namespace OauthService
{

    public static class IdentityExtension
    {
        public static Model.Oauth.Userinfo GetCurrentUser(this IIdentity sender)
        {
            var model =
             JsonConvert.DeserializeObject<Model.Oauth.Userinfo>(sender.ClaimToList().Find(p => p.Type == IdentityServerConstants.StandardScopes.Profile).Value);
            model.DepName = new DepartmentService().GetModelById(model.DepId).DepName;
            return model;
        }
        private static List<Claim> ClaimToList(this IIdentity sender)
        {
            return ((ClaimsIdentity)sender).Claims.ToList();
        }
    }
}
