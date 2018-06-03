using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WaterService
{
    /// <summary>
    /// 附件信息
    /// </summary>
    public class AttachmentInfo : BaseEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int AttachmentId { get; set; }
        /// <summary>
        /// 各种类型主键
        /// </summary>
        public int MeterId { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int GenreId { get; set; }
        public int Resourceid { get; set; }

    }
}
