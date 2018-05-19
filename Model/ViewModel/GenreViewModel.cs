using System;
using System.Collections.Generic;
using System.Text;
using Model.Oauth;
using Model.WaterService;

namespace Model.ViewModel
{
    /// <summary>
    /// 类型 (闸门，水表，管线，排水，消防，排泥，排气)
    /// </summary>
    public class GenreViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public List<GenreInfo> List { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount { get; set; }

    }
}
