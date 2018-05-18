using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    public class DrainageAdd
    {
        public Model.WaterService.UserInfo User { get; set; }
        public Model.WaterService.DrainageInfo Drainage { get; set; }
        public List<Model.WaterService.AttachmentInfo> List { get; set; }
    }
}
