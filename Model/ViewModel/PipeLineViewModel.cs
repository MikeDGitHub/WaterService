using System;
using System.Collections.Generic;
using System.Text;
using Model.WaterService;

namespace Model.ViewModel
{
    public class PipeLineViewModel
    {
        public List<PipeLine> List { get; set; }
        public int TotalCount { get; set; }

    }
    public class PipeLine : BaseViewModel
    {
        public int PipeLineId { get; set; }
        public string PipeLineCode { get; set; }
        public string PipeLineName { get; set; }
        public int TrackId { get; set; }
        public double Acreage { get; set; }
        public double Caliber { get; set; }

        public TrackInfo TrackInfo { get; set; }
    }
}
