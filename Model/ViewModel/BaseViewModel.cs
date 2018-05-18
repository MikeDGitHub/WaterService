using System;
using System.Collections.Generic;
using System.Text;
using Model.WaterService;

namespace Model.ViewModel
{
    public class BaseViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserPhone { get; set; }
        public string Remark { get; set; }
        public string Create { get; set; }
        public DateTime CreateDate { get; set; }
        public string Modify { get; set; }
        public DateTime ModifyDate { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public List<AttachmentInfo> AttachmentList { get; set; }
    }
}
