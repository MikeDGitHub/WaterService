﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    public class SludgeAdd
    {
        public Model.WaterService.UserInfo User { get; set; }
        public Model.WaterService.SludgeInfo Sludge { get; set; }
        public List<Model.WaterService.AttachmentInfo> List { get; set; }
    }
}
