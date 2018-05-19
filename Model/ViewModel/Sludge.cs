using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    /// <summary>
    /// 排泥
    /// </summary>
    public class SludgeAdd : BaseAdd
    {
        /// <summary>
        /// 排泥
        /// </summary>
        public Model.WaterService.SludgeInfo Sludge { get; set; }
    }
    /// <summary>
    /// 排泥
    /// </summary>
    public class SludgeViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Sludge> List { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount { get; set; }
    }
    /// <summary>
    /// 排泥
    /// </summary>
    public class Sludge : ViewModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int SludgeId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string SludgeCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string SludgeName { get; set; }
    }
}
