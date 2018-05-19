using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Oauth
{
    /// <summary>
    /// 应用表
    /// </summary>
    public class ApplicationInfo : BaseEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ApplicationId { get; set; }
        /// <summary>
        /// 应用名称
        /// </summary>
        public string DisplayName { get; set; }
    }
}
