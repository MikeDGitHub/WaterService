using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Newtonsoft.Json;

namespace OauthService
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {

            var clientId = context.Request.Client.ClientId;
            try
            {
                var userId = await new BLL.UserService().Login(context.UserName, context.Password);
                if (userId != 0)
                {
                    var user = await new BLL.UserService().GetUserInfo(userId, int.Parse(clientId));
                    if (user.UserId != 0)
                    {
                        //    //check if password match - remember to hash password if stored as hash in db
                        //    //if (user.Password == context.Password)
                        //    //{
                        //    //set the result
                        context.Result = new GrantValidationResult(
                            subject: user.UserId.ToString(),
                            authenticationMethod: "custom",
                            claims: GetUserClaims(user));

                        //    return;
                        //    //}

                        //    //context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Incorrect password");
                        //    //return;
                    }
                    else
                    {
                        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "User does not exist.");
                        return;
                    }
                }
                else
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest, ex.Message);
            }
        }
        public static Claim[] GetUserClaims(Model.Oauth.Userinfo user)
        {
            return new Claim[]
            {
                new Claim("userId", user.UserId.ToString() ?? ""),
                new Claim("userName",user.UserName),
                new Claim("userEmail",user.UserEmail),
                new Claim("loginName",user.LoginName),
                new Claim("phoneNumber",user.PhoneNumber),
                new Claim("status",user.Status.ToString()),
                new Claim("logoImageUrl",user.LogoImageUrl??""),
                new Claim(IdentityServerConstants.StandardScopes.Profile,JsonConvert.SerializeObject(user)),
                //new Claim("userInfo",JsonConvert.SerializeObject(user)), 
                //roles
                //new Claim(JwtClaimTypes.Role, user.Role)
            };
        }
    }
}
