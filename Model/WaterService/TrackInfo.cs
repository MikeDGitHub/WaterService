using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WaterService
{
    /// <summary>
    /// 轨迹信息
    /// </summary>
    public class TrackInfo : BaseEntity
    {
        public int TrackId { get; set; }
        /// <summary>
        /// 轨迹信息
        /// </summary>
        //public string Coordinate { get; set; }
        /// <summary>
        /// 起始经度
        /// </summary>
        public double StartLat { get; set; }
        /// <summary>
        /// 起始纬度
        /// </summary>
        public double StartLon { get; set; }
        /// <summary>
        /// 结束经度
        /// </summary>
        public double EndLat { get; set; }
        /// <summary>
        /// 结束纬度
        /// </summary>
        public double EndLon { get; set; }
        /// <summary>
        /// 坐标集合
        /// </summary>
        public List<Coordinate> Coordinate { get; set; }
    }
    /// <summary>
    /// 坐标
    /// </summary>
    public class Coordinate
    {
        public double Latitude { get; set; }
        public double LatitudeE6 { get; set; }
        public double Longitude { get; set; }
        public double LongitudeE6 { get; set; }
    }
}
