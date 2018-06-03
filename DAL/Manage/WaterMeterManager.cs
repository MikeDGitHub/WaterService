﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;
using Model.ViewModel;
using Model.WaterService;

namespace DAL.Manage
{
    public class WaterMeterManager
    {
        public bool Add(UserInfo user, WaterMeterInfo water, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("insert into WaterService.WaterMeterInfo(WaterCode,WaterName,TypeId,GenreId,Caliber,Lat,Lon,`Create`,CreateDate,Acreage) values('{0}','{1}',{2},{3},{4},{5},{6},'{7}','{8}',{9});select @@IDENTITY;", water.WaterMeterCode, water.WaterMeterName, water.TypeId, water.GenreId, water.Caliber, water.Lat, water.Lon, user.Create, user.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), water.Acreage);
            var id = int.Parse(new MySqlHelper().ExecuteScalar(sb.ToString()).ToString());
            new UserManage().Add_WaterService_UserInfo(user, id);
            new AttachmentManager().AddList(list, id, user.Create, user.CreateDate, water.GenreId);
            new MaintenanceManager().Add(new MaintenanceInfo()
            {
                MeterId = int.Parse(id.ToString()),
                GenreId = water.GenreId,
                TypeId = water.TypeId,
                Create = user.Create,
                CreateDate = DateTime.Now,
                InstallTime = DateTime.Now,
            });
            return id != 0;
        }

        public bool Update(UserInfo user, WaterMeterInfo water, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();

            if (water != null)
            {
                sb.AppendFormat("update WaterService.WaterMeterInfo set GenreId={0},TypeId={1},Caliber={2},Lat={3},Lon={4},Modify='{5}',ModifyDate='{6}',WaterCode='{7}',WaterName='{8}',Acreage={10} where WaterId={9};", water.GenreId, water.TypeId, water.Caliber, water.Lat, water.Lon, water.Modify, water.ModifyDate.ToString("yyyy-MM-dd HH:mm:ss"), water.WaterMeterCode, water.WaterMeterName, water.WaterMeterId, water.Acreage);
                new AttachmentManager().AddList(list, water.WaterMeterId, water.Create, DateTime.Now, water.GenreId);
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
        public WaterMeterViewModel GetList(string where)
        {
            var water = new WaterMeterViewModel();
            var sql = "select WaterId,WaterCode,WaterName,Acreage,Caliber,Lat,Lon,ui.UserId,ui.UserName,ui.UserAddress,ui.UserPhone,ui.Remark,ui.`Create`,ui.CreateDate,ui.Modify,ui.ModifyDate,gi.GenreId,gi.GenreName,ti.TypeId,ti.TypeName from  waterservice.WaterMeterInfo va join waterservice.userinfo ui on ui.MeterId = water.WaterId join waterservice.genreinfo gi on gi.GenreId = water.GenreId join waterservice.typeinfo ti on ti.TypeId = water.TypeId " + where;
            water.List = new MySqlHelper().FindToList<WaterMeter>(sql).ToList();
            water.TotalCount = water.List.Count;
            return water;
        }
    }
}
