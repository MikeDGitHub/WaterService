using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WaterService
{
    public class PipeLineInfo : InfoBase
    {
        public int PipeLineId { get; set; }
        public string PipeLineCodeName { get; set; }
        public string PipeLineName { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        public double Acreage { get; set; }
        /// <summary>
        /// 轨迹
        /// </summary>
        public int TrackId { get; set; }
    }
}
