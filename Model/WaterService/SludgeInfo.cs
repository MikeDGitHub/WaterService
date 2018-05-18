using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WaterService
{
    /// <summary>
    /// 排泥信息
    /// </summary>
    public class SludgeInfo : InfoBase
    {
        public int SludgeId { get; set; }
        public string SludgeCode { get; set; }
        public string SludgeName { get; set; }
    }
}
