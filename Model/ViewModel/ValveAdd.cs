using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.WaterService;

namespace Model.ViewModel
{
    public class ValveAdd
    {
        public Model.WaterService.UserInfo User { get; set; }
        public Model.WaterService.ValveInfo Valve { get; set; }
        public List<Model.WaterService.AttachmentInfo> List { get; set; }
    }
}
