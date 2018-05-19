using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    /// <summary>
    /// 水表
    /// </summary>
    public class WaterMeterAdd : BaseAdd
    {
        /// <summary>
        /// 
        /// </summary>
        public Model.WaterService.WaterMeterInfo WaterMeter { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class WaterMeterViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public List<WaterMeter> List { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount { get; set; }
    }
    /// <summary>
    /// 水表
    /// </summary>
    public class WaterMeter : ViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int WaterMeterId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WaterMeterCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WaterMeterName { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        public double Acreage { get; set; }

    }
}
