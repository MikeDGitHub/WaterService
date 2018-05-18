using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WaterService
{
    /// <summary>
    /// 排气信息
    /// </summary>
    public class ExhaustInfo : InfoBase
    {
        public string ExhaustCode { get; set; }
        public int ExhaustId { get; set; }
        public string ExhaustName { get; set; }
    }
}
