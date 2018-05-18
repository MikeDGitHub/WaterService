using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WaterService
{
    /// <summary>
    /// 类型表
    /// 主管道，一级管道，二级管道
    /// </summary>
    public class TypeInfo : BaseEntity
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
