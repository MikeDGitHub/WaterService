using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ACL
{
    /// <summary>
    /// 应用和用户关系
    /// </summary>
    public class ApplicationAndUser
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public int ApplicationId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
    }
}
