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
        /// <summary>
        /// 
        /// </summary>
        public int MeterId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int GenreId { get; set; }
        /// <summary>
        /// 安装时间
        /// </summary>
        public DateTime InstallTime { get; set; }
        /// <summary>
        ///更换时间
        /// </summary>
        public DateTime ReplaceTime = DateTime.Now;
    }
}
