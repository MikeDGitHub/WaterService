using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Oauth
{
    public class ApplicationInfo : BaseEntity
    {
        public int ApplicationId { get; set; }
        public string DisplayName { get; set; }
    }
}
