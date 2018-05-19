using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    /// <summary>
    /// 更新
    /// </summary>
    public class UpdateModel
    {
        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPassWord { get; set; }
        /// <summary>
        /// 旧密码
        /// </summary>
        public string OldPassWord { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string LogoImageUrl { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public int DepId { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
