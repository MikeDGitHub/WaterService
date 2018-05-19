using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    /// <summary>
    ///排水
    /// </summary>
    public class DrainageAdd : BaseAdd
    {
        /// <summary>
        ///排水
        /// </summary>
        public Model.WaterService.DrainageInfo Drainage { get; set; }

    }
    /// <summary>
    /// view
    /// </summary>
    public class DrainageViewModel
    {
        /// <summary>
        /// 排水集合
        /// </summary>
        public List<Drainage> List { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int TotalCount { get; set; }
    }
    /// <summary>
    /// 排水
    /// </summary>
    public class Drainage : ViewModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int DrainageId { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string DrainageCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string DrainageName { get; set; }

    }
}
