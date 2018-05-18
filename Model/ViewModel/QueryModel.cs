using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    public class QueryModel
    {
        public string Address { get; set; }
        public int GenreId { get; set; }
        public int TypeId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize = 10;
        public string Name { get; set; }
    }
}
