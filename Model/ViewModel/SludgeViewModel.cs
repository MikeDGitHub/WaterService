using System;
using System.Collections.Generic;
using System.Text;
using Model.WaterService;

namespace Model.ViewModel
{
    public class SludgeViewModel
    {
        public List<Sludge> List { get; set; }
        public int TotalCount { get; set; }
    }
    public class Sludge : BaseViewModel
    {
        public int SludgeId { get; set; }
        public string SludgeCode { get; set; }
        public string SludgeName { get; set; }
        public double Caliber { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

    }
}
