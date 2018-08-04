using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.WaterService;

namespace Model.ViewModel
{
    /// <summary>
    /// 阀门
    /// </summary>
    public class ValveAdd : BaseAdd
    {
        /// <summary>
        /// 阀门
        /// </summary>
        public Model.WaterService.ValveInfo Valve { get; set; }
    }
    /// <summary>
    /// 阀门
    /// </summary>
    public class ValveViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Valve> List { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount { get; set; }
    }
    /// <summary>
    /// 阀门
    /// </summary>
    public class Valve : ViewModel
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int ValveId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string ValveCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ValveName { get; set; }
        public string ControlScope { get; set; }

    }
}
