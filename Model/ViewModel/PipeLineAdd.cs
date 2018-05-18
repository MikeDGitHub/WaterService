using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    public class PipeLineAdd
    {
        public Model.WaterService.UserInfo User { get; set; }
        public Model.WaterService.PipeLineInfo PipeLine { get; set; }
        public List<Model.WaterService.AttachmentInfo> List { get; set; }
        public Model.WaterService.TrackInfo Track { get; set; }
    }
}
