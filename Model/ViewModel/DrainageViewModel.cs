using System;
using System.Collections.Generic;
using System.Text;
using Model.WaterService;

namespace Model.ViewModel
{
    public class DrainageViewModel
    {
        public List<Drainage> List { get; set; }
        public int TotalCount { get; set; }
    }
    public class Drainage : BaseViewModel
    {
        public int DrainageId { get; set; }
        public string DrainageCode { get; set; }
        public string DrainageName { get; set; }
        public double Caliber { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

    }
}
