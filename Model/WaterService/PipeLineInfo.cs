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
        public string PipeLineCode { get; set; }
        public string PipeLineName { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        public double Acreage { get; set; }
        /// <summary>
        /// 轨迹
        /// </summary>
        public int TrackId { get; set; }
        /// <summary>
        /// 起始地址
        /// </summary>

        public string StartAddress { get; set; }
        /// <summary>
        /// 结束地址
        /// </summary>

        public string EndAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public int ModelId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModelName { get; set; }
    }
}
