using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Oauth
{
    public class UserPassword
    {
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string PasswordType { get; set; }
        public string AlgorithmType { get; set; }
        public string PassWord { get; set; }
    }
}
