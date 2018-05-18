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
        public string LoginName { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string LogoImageUrl { get; set; }
        public int DepId { get; set; }
        public bool Status { get; set; }
    }
}
