using System;
using System.Collections.Generic;
using System.Text;
using Model.WaterService;

namespace Model.ViewModel
{
    public class ExhaustViewModel
    {
        public List<Exhaust> List { get; set; }
        public int TotalCount { get; set; }
    }
    public class Exhaust : BaseViewModel
    {
        public int ExhaustId { get; set; }
        public string ExhaustCode { get; set; }
        public string ExhaustName { get; set; }
        public double Caliber { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

    }
}
