using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;

namespace DAL.Manage
{
    public class ModelManage
    {
        public List<Model.WaterService.ModelInfo> QueryList()
        {
            var sql = "select * from WaterService.Modelinfo";
            return new MySqlHelper().FindToList<Model.WaterService.ModelInfo>(sql).ToList();
        }
    }
}
