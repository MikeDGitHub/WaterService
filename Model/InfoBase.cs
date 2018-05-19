using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 
    /// </summary>
    public class InfoBase : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int GenreId { get; set; }
        /// <summary>
        /// 口径
        /// </summary>
        public double Caliber { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double Lon { get; set; }
    }
}
