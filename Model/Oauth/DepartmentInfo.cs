using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Oauth
{
    /// <summary>
    /// 部门表
    /// </summary>
    public class DepartmentInfo : BaseEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int DepId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepName { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentId { get; set; }
    }
}
