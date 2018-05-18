using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WaterService
{
    /// <summary>
    /// 类型表
    /// 闸门，水表，管线，排水，消防，排泥，排气
    /// </summary>
    public class GenreInfo : BaseEntity
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
