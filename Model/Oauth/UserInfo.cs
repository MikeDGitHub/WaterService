using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Oauth
{
    public class Userinfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string LoginName { get; set; }
        public string PhoneNumber { get; set; }
        public string LogoImageUrl { get; set; }
        public string UserEmail { get; set; }
        public int Status { get; set; }
    }

    public class UserInfoViewModel
    {
        public List<Userinfo> List { get; set; }
        public int TotalCount { get; set; }
    }
}
