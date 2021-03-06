﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;
using Model.ViewModel;
using Model.WaterService;

namespace DAL.Manage
{
    public class DrainageManager
    {
        public int Add(UserInfo user, DrainageInfo drainage, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("insert into waterService.drainageInfo(DrainageCode,DrainageName,TypeId,GenreId,Caliber,Lat,Lon,`Create`,CreateDate) values('{0}','{1}',{2},{3},{4},{5},{6},'{7}','{8}');select @@IDENTITY;", drainage.DrainageCode, drainage.DrainageName, drainage.TypeId, drainage.GenreId, drainage.Caliber, drainage.Lat, drainage.Lon, user.Create, drainage.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"));
            var id = int.Parse(new MySqlHelper().ExecuteScalar(sb.ToString()).ToString());
            new UserManage().Add_WaterService_UserInfo(user, id);
            new AttachmentManager().AddList(list, id, user.Create, user.CreateDate, drainage.GenreId);
            new MaintenanceManager().Add(new MaintenanceInfo()
            {
                MeterId = int.Parse(id.ToString()),
                GenreId = drainage.GenreId,
                TypeId = drainage.TypeId,
                Create = user.Create,
                CreateDate = DateTime.Now,
                InstallTime = DateTime.Now,
            });
            return id;
        }
        public bool Update(UserInfo user, DrainageInfo drainage, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            if (drainage != null)
            {
                sb.AppendFormat("update waterService.drainageInfo set GenreId={0},TypeId={1},Caliber={2},Lat={3},Lon={4},Modify='{5}',ModifyDate='{6}',DrainageCode='{7}',DrainageName='{8}' where DrainageId={9};", drainage.GenreId, drainage.TypeId, drainage.Caliber, drainage.Lat, drainage.Lon, drainage.Modify, drainage.ModifyDate.ToString("yyyy-MM-dd HH:mm:ss"), drainage.DrainageCode, drainage.DrainageName, drainage.DrainageId);
                new AttachmentManager().AddList(list, drainage.DrainageId, drainage.Create, DateTime.Now, drainage.GenreId);
            }
            new UserManage().UpDate_WaterService_UserInfo(user);
            return new MySqlHelper().ExcuteNonQuery(sb.ToString()) > 0;
        }
        public DrainageViewModel GetList(string where)
        {
            var drainage = new DrainageViewModel();
            var sql = "select * from waterservice.DrainageView " + where;
            drainage.List = new MySqlHelper().FindToList<Drainage>(sql).ToList();
            drainage.TotalCount = drainage.List.Count;
            return drainage;
        }
    }
}
