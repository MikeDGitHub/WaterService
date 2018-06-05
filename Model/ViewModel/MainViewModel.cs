using System;
using System.Collections.Generic;
using System.Text;
using Model.WaterService;

namespace Model.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class MainViewModel : InfoBase
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        public TrackInfo TrackInfo { get; set; }
        public string GenreName { get; set; }
        public string TypeName { get; set; }
        public string Remark { get; set; }
        public string UserAddress { get; set; }
        public int TrackId { get; set; }
        public List<AttachmentInfo> AttachmentList { get; set; }
    }
}
