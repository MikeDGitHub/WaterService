using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WaterService
{
    /// <summary>
    /// 阀门信息
    /// </summary>
    public class ValveInfo : InfoBase
    {
        public int ValveId { get; set; }
        public string ValveCode { get; set; }
        public string ValveName { get; set; }
    }
}
