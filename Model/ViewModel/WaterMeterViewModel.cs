using System;
using System.Collections.Generic;
using System.Text;
using Model.WaterService;

namespace Model.ViewModel
{
    public class WaterMeterViewModel
    {
        public List<WaterMeter> List { get; set; }
        public int TotalCount { get; set; }
    }
    public class WaterMeter : BaseViewModel
    {
        public int WaterMeterId { get; set; }
        public string WaterMeterCode { get; set; }
        public string WaterMeterName { get; set; }
        public double Caliber { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double Acreage { get; set; }

    }
}
