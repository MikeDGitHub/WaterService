using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WaterService
{
    /// <summary>
    /// 泄水信息
    /// </summary>
    public class DrainageInfo : InfoBase
    {
        public int DrainageId { get; set; }
        public string DrainageCode { get; set; }
        public string DrainageName { get; set; }
    }
}
