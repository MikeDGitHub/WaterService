using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Newtonsoft.Json;

namespace OauthService
{
    public class ProfileService : IProfileService
    {
        //Get user profile date in terms of claims when calling /connect/userinfo
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {

                //depending on the scope accessing the user data.
                if (!string.IsNullOrEmpty(context.Subject.Identity.Name))
                {
                    //get user from db (in my case this is by email)
                    ;
                    var user = JsonConvert.DeserializeObject<Model.Oauth.Userinfo>(((System.Security.Claims.ClaimsIdentity)context.Subject.Identity).Claims.ToList().Find(p => p.Type == IdentityServerConstants.StandardScopes.Profile).Value);//await _userRepository.FindAsync(context.Subject.Identity.Name);

                    if (user != null)
                    {
                        var claims = GetUserClaims(user);

                        //    //set issued claims to return
                        context.IssuedClaims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                    }
                }
                else
                {
                    //get subject from context (this was set ResourceOwnerPasswordValidator.ValidateAsync),
                    //where and subject was set to my user id.
                    var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "sub");

                    if (!string.IsNullOrEmpty(userId?.Value) && long.Parse(userId.Value) > 0)
                    {
                        //get user from db (find user by user id)
                        //var user = await _userRepository.FindAsync(long.Parse(userId.Value));
                        var user = JsonConvert.DeserializeObject<Model.Oauth.Userinfo>(((System.Security.Claims.ClaimsIdentity)context.Subject.Identity).Claims.ToList().Find(p => p.Type == IdentityServerConstants.StandardScopes.Profile).Value);
                        //// issue the claims for the user
                        if (user != null)
                        {
                            var claims = ResourceOwnerPasswordValidator.GetUserClaims(user);

                            context.IssuedClaims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type))
                                .ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log your error
            }
        }

        //check if user account is active.
        public async Task IsActiveAsync(IsActiveContext context)
        {
            try
            {
                //get subject from context (set in ResourceOwnerPasswordValidator.ValidateAsync),
                var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "user_id");

                if (!string.IsNullOrEmpty(userId?.Value) && long.Parse(userId.Value) > 0)
                {
                    //var user = await _userRepository.FindAsync(long.Parse(userId.Value));

                    //if (user != null)
                    //{
                    //    if (user.IsActive)
                    //    {
                    //        context.IsActive = user.IsActive;
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                //handle error logging
            }
        }
        public static Claim[] GetUserClaims(Model.Oauth.Userinfo user)
        {
            return new Claim[]
            {
                new Claim("user_id", user.UserId.ToString()),
                new Claim(JwtClaimTypes.Name,user.UserName),
                new Claim(JwtClaimTypes.Email, user.UserEmail ),
                new Claim(JwtClaimTypes.Profile,JsonConvert.SerializeObject(user)),

                ////roles
                //new Claim(JwtClaimTypes.Role, user.Role)
            };
        }
    }
}
