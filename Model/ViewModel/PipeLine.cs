using System;
using System.Collections.Generic;
using System.Text;
using Model.WaterService;

namespace Model.ViewModel
{
    /// <summary>
    /// 管线
    /// </summary>
    public class PipeLineAdd : BaseAdd
    {
        /// <summary>
        /// 管线
        /// </summary>
        public Model.WaterService.PipeLineInfo PipeLine { get; set; }
        /// <summary>
        /// 轨迹
        /// </summary>
        public Model.WaterService.TrackInfo Track { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class PipeLineViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public List<PipeLine> List { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class PipeLine : BaseViewModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int PipeLineId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string PipeLineCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string PipeLineName { get; set; }
        /// <summary>
        /// 轨迹主键
        /// </summary>
        public int TrackId { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        public double Acreage { get; set; }
        /// <summary>
        /// 口径
        /// </summary>
        public double Caliber { get; set; }
        /// <summary>
        /// 轨迹
        /// </summary>

        public TrackInfo TrackInfo { get; set; }
        /// <summary>
        /// 起始地址
        /// </summary>

        public string StartAddress { get; set; }
        /// <summary>
        /// 结束地址
        /// </summary>

        public string EndAddress { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
    }
}
