using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WaterService
{
    /// <summary>
    /// 水表信息
    /// </summary>
    public class WaterMeterInfo : InfoBase
    {
        public int WaterMeterId { get; set; }
        public string WaterMeterCode { get; set; }
        public string WaterMeterName { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        public double Acreage { get; set; }
    }
}
