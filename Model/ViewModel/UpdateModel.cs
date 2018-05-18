using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    public class UpdateModel
    {
        public string NewPassWord { get; set; }
        public string OldPassWord { get; set; }
        public string LogoImageUrl { get; set; }
        public int UserId { get; set; }
        public int DepId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
