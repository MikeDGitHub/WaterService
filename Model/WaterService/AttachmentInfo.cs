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
        public int AttachmentId { get; set; }
        public int MeterId { get; set; }
        public string ImgUrl { get; set; }
        public int GenreId { get; set; }

    }
}
