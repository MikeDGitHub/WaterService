using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Oauth
{
    public class DepartmentInfo : BaseEntity
    {
        public int DepId { get; set; }
        public string DepName { get; set; }
        public int ParentId { get; set; }
    }
}
