using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;
using IdentityServer4;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Model.ViewModel;
using Newtonsoft.Json.Linq;

namespace OauthService.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        [HttpPost, Route("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterModel register)
        {
            var obj = new JObject();
            obj.Add("status", 200);
            if (new BLL.UserService().CheckPhoneNumber(register.Mobile))
            {
                obj.Add("error", "手机号已存在。");
            }
            else if (new BLL.UserService().CheckLoginName(register.LoginName))
            {
                obj.Add("error", "用户名已存在。");
            }
            else
            {
                obj.Add("error", new BLL.UserService().AddUser(register));
            }
            return Ok(obj);
        }
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        [HttpPost, Route("updatePassWord")]
        public IActionResult UpdatePassWord([FromBody] UpdateModel update)
        {
            var obj = new JObject();
            obj.Add("status", 200);
            obj.Add("error",
                new BLL.UserService().UpdatePassWord(update.NewPassWord, update.OldPassWord,
                    User.Identity.GetCurrentUser().UserId));
            return Ok(obj);
        }
        /// <summary>
        /// 更换头像
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        [HttpPost, Route("updateUserInfo")]
        public IActionResult UpdateUserInfo([FromBody] UpdateModel update)
        {
            var obj = new JObject();
            obj.Add("status", 200);
            if (!string.IsNullOrEmpty(update.LogoImageUrl))
            {
                obj.Add("error", new BLL.UserService().UpdateLogoImageUrl(update.LogoImageUrl, User.Identity.GetCurrentUser().UserId));

            }
            if (!string.IsNullOrEmpty(update.PhoneNumber))
            {
                obj.Add("error", new BLL.UserService().UpdatePhoneNumber(update.PhoneNumber, User.Identity.GetCurrentUser().UserId));
            }
            return Ok(obj);
        }
        /// <summary>
        /// 设置用户部门
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("updateDepartment")]
        public IActionResult UpdateDepartment([FromBody] UpdateModel update)
        {
            var obj = new JObject();
            obj.Add("status", 200);
            obj.Add("error", new BLL.UserService().UpdateDepartment(update.DepId, update.UserId));
            return Ok(obj);
        }

        [HttpGet, Route("logOut")]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync("oauth");
            return Ok();
        }
        [HttpGet, Route("logIn")]
        public IActionResult LogIn()
        {
            HttpContext.SignInAsync("oauth", User);
            return Ok();
        }
        [HttpGet, Route("getIdentity")]
        public Model.Oauth.Userinfo GetIdentity()
        {
            return User.Identity.GetCurrentUser();
        }
        [HttpPost, Route("queryUserList")]
        public IActionResult QueryUserList([FromBody]QueryModel query)
        {
            return Ok(new BLL.UserService().QueryUserList(query));
        }
        [HttpGet, Route("queryUserInfo")]
        public IActionResult QueryUserInfo([FromQuery] int id)
        {
            return Ok(new BLL.UserService().QueryUserInfo(id));
        }
    }
}
