using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    public class ExhaustAdd
    {
        public Model.WaterService.UserInfo User { get; set; }
        public Model.WaterService.ExhaustInfo Exhaust { get; set; }
        public List<Model.WaterService.AttachmentInfo> List { get; set; }
    }
}
