using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Oauth
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class Userinfo
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        /// <returns></returns>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        /// <returns></returns>
        public string LogoImageUrl { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        /// <returns></returns>
        public string UserEmail { get; set; }
        /// <summary>
        /// 状态0禁用1启用
        /// </summary>
        /// <returns></returns>
        public int Status { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public int DepId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DepName { get; set; }
        public string Password { get; set; }
    }
    /// <summary>
    /// view
    /// </summary>
    public class UserInfoViewModel
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public List<Userinfo> List { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int TotalCount { get; set; }
    }
}
