using System;
using System.Collections.Generic;
using System.Text;

namespace Model.WaterService
{
    /// <summary>
    /// 消防
    /// </summary>
    public class FireFightingInfo : InfoBase
    {
        public int FireFightingId { get; set; }
        public string FireFightingCode { get; set; }
        public string FireFightingName { get; set; }
    }
}
