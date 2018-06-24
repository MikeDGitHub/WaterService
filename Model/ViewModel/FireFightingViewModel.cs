using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel

{
    public class FireFightingAdd : BaseAdd
    {
        /// <summary>
        /// 阀门
        /// </summary>
        public Model.WaterService.FireFightingInfo FireFighting { get; set; }
    }
    public class FireFightingViewModel
    {
        public List<FireFighting> List { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount { get; set; }
    }

    public class FireFighting : ViewModel
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int FireFightingId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string FireFightingCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FireFightingName { get; set; }

    }
}
