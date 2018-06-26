using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchModel
    {

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int GenreId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PageSize = 10;
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 起始地址
        /// </summary>

        public string StartAddress { get; set; }
        /// <summary>
        /// 结束地址
        /// </summary>

        public string EndAddress { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MainQuery
    {
        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 距离（单位：公里或千米）
        /// </summary>
        public double Distance { get; set; }
    }

    public class QueryInfo
    {
        public int Id { get; set; }
    }
}
