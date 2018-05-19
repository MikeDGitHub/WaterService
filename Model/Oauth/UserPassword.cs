using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Oauth
{
    /// <summary>
    /// 密码
    /// </summary>
    public class UserPassword
    {
        /// <summary>
        /// 用户表主键
        /// </summary>
        /// <returns></returns>
        public int UserId { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        /// <returns></returns>
        public string LoginName { get; set; }
        /// <summary>
        /// 密码类型
        /// </summary>
        /// <returns></returns>
        public string PasswordType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string AlgorithmType { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        /// <returns></returns>
        public string PassWord { get; set; }
    }
}
