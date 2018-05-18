using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WaterService
{
    public class UserInfo : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserPhone { get; set; }
        public int MeterId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
