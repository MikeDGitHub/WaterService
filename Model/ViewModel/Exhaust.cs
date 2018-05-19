using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    /// <summary>
    /// 排气
    /// </summary>
    public class ExhaustAdd : BaseAdd
    {
        /// <summary>
        /// 排气
        /// </summary>
        public Model.WaterService.ExhaustInfo Exhaust { get; set; }
    }
    /// <summary>
    /// 排气
    /// </summary>
    public class ExhaustViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public List<Exhaust> List { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount { get; set; }
    }
    /// <summary>
    /// 排气
    /// </summary>
    public class Exhaust : ViewModel
    {
        /// <summary>
        /// 主键ID    
        /// </summary>
        public int ExhaustId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ExhaustCode { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string ExhaustName { get; set; }

    }
}
