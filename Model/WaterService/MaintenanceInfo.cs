using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WaterService
{
    /// <summary>
    /// 维保信息
    /// </summary>
    public class MaintenanceInfo : BaseEntity
    {
        public int MeterId { get; set; }
        public int TypeId { get; set; }
        public int GenreId { get; set; }
        /// <summary>
        /// 安装时间
        /// </summary>
        public DateTime InstallTime { get; set; }
        //更换时间
        public DateTime ReplaceTime { get; set; }
    }
}
