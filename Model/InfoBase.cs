using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class InfoBase : BaseEntity
    {
        public int TypeId { get; set; }
        public int GenreId { get; set; }
        /// <summary>
        /// 口径
        /// </summary>
        public double Caliber { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
