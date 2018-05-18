using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    public class WaterMeterAdd
    {
        public Model.WaterService.UserInfo User { get; set; }
        public Model.WaterService.WaterMeterInfo WaterMeter { get; set; }
        public List<Model.WaterService.AttachmentInfo> List { get; set; }
    }
}
