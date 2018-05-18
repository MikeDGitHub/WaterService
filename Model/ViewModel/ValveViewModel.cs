using System;
using System.Collections.Generic;
using System.Text;
using Model.WaterService;

namespace Model.ViewModel
{
    public class ValveViewModel
    {
        public List<Valve> List { get; set; }
        public int TotalCount { get; set; }
    }

    public class Valve : BaseViewModel
    {
        public int ValveId { get; set; }
        public string ValveCode { get; set; }
        public string ValveName { get; set; }
        public double Caliber { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

    }
}
