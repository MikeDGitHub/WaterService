using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    /// <summary>
    /// 注册用户业务数据
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// 短信验证服务ID
        /// </summary>
        public string SessionID { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 短信验证码
        /// </summary>
        public string MarkCode { get; set; }
        /// <summary>
        /// ApplicationId
        /// </summary>
        public int ClientId { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string UserEmail { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string LogoImageUrl { get; set; }
        /// <summary>
        /// 部门主键
        /// </summary>
        public int DepId { get; set; }
        /// <summary>
        /// 状态0禁用1启用
        /// </summary>
        public bool Status { get; set; }
    }
}
