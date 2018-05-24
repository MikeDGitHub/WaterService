using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DAL.Helper;
using Model.WaterService;

namespace DAL.Manage
{
    public class MaintenanceManager
    {
        public bool Add(MaintenanceInfo maintenance)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(
                "insert into WaterService.MaintenanceInfo (MeterId,GenreId,TypeId,InstallTime,`Create`,CreateDate,ReplaceTime) values ({0},{1},{2},'{3}','{4}','{5}','{6}');", maintenance.MeterId, maintenance.GenreId, maintenance.TypeId, maintenance.InstallTime.ToString("yyyy-MM-dd HH:mm:ss"), maintenance.Create, maintenance.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), maintenance.ReplaceTime.ToString("yyyy-MM-dd HH:mm:ss"));
            return new MySqlHelper().ExcuteNonQuery(sb.ToString()) > 0;
        }

        public List<MaintenanceInfo> GetList(string where)
        {
            var sql = "select * from WaterService.MaintenanceInfo " + where;
            return new MySqlHelper().FindToList<MaintenanceInfo>(sql).ToList();
        }
    }
}

