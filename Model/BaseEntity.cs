using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BaseEntity
    {

        public int Status { get; set; }
        public string Create { get; set; }
        public DateTime CreateDate { get; set; }
        public string Modify { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
