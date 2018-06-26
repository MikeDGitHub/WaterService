using DAL.Helper;
using Model.WaterService;
using System;
using System.Collections.Generic;
using System.Text;
using Model.ViewModel;
using System.Linq;

namespace DAL.Manage
{
    public class FireFightingManage
    {
        public int Add(UserInfo user, Model.WaterService.FireFightingInfo fireFighting, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("insert into WaterService.fireFightingInfo(fireFightingCode,fireFightingName,TypeId,GenreId,Caliber,Lat,Lon,`Create`,CreateDate) values('{0}','{1}',{2},{3},{4},{5},{6},'{7}','{8}');select @@IDENTITY;", fireFighting.FireFightingCode, fireFighting.FireFightingName, fireFighting.TypeId, fireFighting.GenreId, fireFighting.Caliber, fireFighting.Lat, fireFighting.Lon, user.Create, fireFighting.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"));
            var id = int.Parse(new MySqlHelper().ExecuteScalar(sb.ToString()).ToString());
            new UserManage().Add_WaterService_UserInfo(user, id);
            new AttachmentManager().AddList(list, id, user.Create, user.CreateDate, fireFighting.GenreId);
            new MaintenanceManager().Add(new MaintenanceInfo()
            {
                MeterId = int.Parse(id.ToString()),
                GenreId = fireFighting.GenreId,
                TypeId = fireFighting.TypeId,
                Create = user.Create,
                CreateDate = DateTime.Now,
                InstallTime = DateTime.Now,
            });
            return id;
        }
        public bool Update(UserInfo user, Model.WaterService.FireFightingInfo fireFighting, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            if (fireFighting != null)
            {
                sb.AppendFormat("update WaterService.fireFightingInfo set GenreId={0},TypeId={1},Caliber={2},Lat={3},Lon={4},Modify='{5}',ModifyDate='{6}',fireFightingCode='{7}',fireFightingName='{8}' where fireFightingId={9};", fireFighting.GenreId, fireFighting.TypeId, fireFighting.Caliber, fireFighting.Lat, fireFighting.Lon, fireFighting.Modify, fireFighting.ModifyDate.ToString("yyyy-MM-dd HH:mm:ss"), fireFighting.FireFightingCode, fireFighting.FireFightingName, fireFighting.FireFightingId);
                new AttachmentManager().AddList(list, fireFighting.FireFightingId, fireFighting.Create, fireFighting.CreateDate, fireFighting.GenreId);
            }
            new UserManage().UpDate_WaterService_UserInfo(user);

            if (sb.Length > 1)
            {
                return new MySqlHelper().ExcuteNonQuery(sb.ToString()) > 0;
            }
            else
            {
                return false;
            }

        }
        public FireFightingViewModel GetList(string where)
        {
            var fireFighting = new FireFightingViewModel();
            var sql = "select * from waterservice.firefightingview" + where;
            fireFighting.List = new MySqlHelper().FindToList<FireFighting>(sql).ToList();
            fireFighting.TotalCount = fireFighting.List.Count;
            return fireFighting;
        }
    }
}
