using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
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
    /// <summary>
    /// 用户注册
    /// </summary>
    [Authorize]
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
        public ResultModel Register([FromBody] RegisterModel register)
        {
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            if (new BLL.UserService().CheckPhoneNumber(register.Mobile))
            {
                m.Msg = "手机号已存在。";
            }
            else if (new BLL.UserService().CheckLoginName(register.LoginName))
            {
                m.Msg = "用户名已存在。";
            }
            else
            {
                m.Status = new BLL.UserService().AddUser(register);
            }
            return m;
        }
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        [HttpPost, Route("updatePassWord")]
        public ResultModel UpdatePassWord([FromBody] UpdateModel update)
        {
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Status = true;
            m.Msg = new BLL.UserService().UpdatePassWord(update.NewPassWord, update.OldPassWord,
                User.Identity.GetCurrentUser().UserId);
            return m;
        }
        /// <summary>
        /// 更换头像
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        [HttpPost, Route("updateUserInfo")]
        public ResultModel UpdateUserInfo([FromBody] UpdateModel update)
        {
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            if (!string.IsNullOrEmpty(update.LogoImageUrl))
            {
                m.Status = new BLL.UserService().UpdateLogoImageUrl(update.LogoImageUrl, User.Identity.GetCurrentUser().UserId);

            }
            if (!string.IsNullOrEmpty(update.PhoneNumber))
            {
                m.Status = new BLL.UserService().UpdatePhoneNumber(update.PhoneNumber, User.Identity.GetCurrentUser().UserId);
            }
            return m;
        }
        /// <summary>
        /// 设置用户部门
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("updateDepartment")]
        public ResultModel UpdateDepartment([FromBody] UpdateModel update)
        {
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Status = new BLL.UserService().UpdateDepartment(update.DepId, update.UserId);
            return m;
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("logOut")]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync("oauth");
            return Ok();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("logIn")]
        public IActionResult LogIn()
        {
            HttpContext.SignInAsync("oauth", User);
            return Ok();
        }
        /// <summary>
        ///获取当前人信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("getIdentity")]
        public ResultModel GetIdentity()
        {
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Json = User.Identity.GetCurrentUser();
            return m;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost, Route("queryUserList")]
        public ResultModel QueryUserList([FromBody]SearchModel query)
        {
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Json = new BLL.UserService().QueryUserList(query);
            return m;
        }
        /// <summary>
        /// 查询通过id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("queryUserInfo")]
        public ResultModel QueryUserInfo([FromQuery] int id)
        {
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Json = new BLL.UserService().QueryUserInfo(id);
            return m;
        }
    }
}
