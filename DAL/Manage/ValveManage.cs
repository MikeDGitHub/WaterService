using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using DAL.Helper;
using Model.ViewModel;
using Model.WaterService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DAL.Manage
{
    public class ValveManage
    {
        public int Add(UserInfo user, ValveInfo valve, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("insert into WaterService.ValveInfo(ValveCode,ValveName,TypeId,GenreId,Caliber,Lat,Lon,`Create`,CreateDate,ControlScope) values('{0}','{1}',{2},{3},{4},{5},{6},'{7}','{8}','{9}');select @@IDENTITY;", valve.ValveCode, valve.ValveName, valve.TypeId, valve.GenreId, valve.Caliber, valve.Lat, valve.Lon, user.Create, valve.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), valve.ControlScope);
            var id = int.Parse(new MySqlHelper().ExecuteScalar(sb.ToString()).ToString());
            new UserManage().Add_WaterService_UserInfo(user, id);
            new AttachmentManager().AddList(list, id, user.Create, user.CreateDate, valve.GenreId);
            new MaintenanceManager().Add(new MaintenanceInfo()
            {
                MeterId = int.Parse(id.ToString()),
                GenreId = valve.GenreId,
                TypeId = valve.TypeId,
                Create = user.Create,
                CreateDate = DateTime.Now,
                InstallTime = DateTime.Now,
            });
            return id;
        }
        public bool Update(UserInfo user, ValveInfo valve, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            if (valve != null)
            {
                sb.AppendFormat("update WaterService.ValveInfo set GenreId={0},TypeId={1},Caliber={2},Lat={3},Lon={4},Modify='{5}',ModifyDate='{6}',ValveCode='{7}',ValveName='{8}',ControlScope='{10}' where ValveId={9};", valve.GenreId, valve.TypeId, valve.Caliber, valve.Lat, valve.Lon, valve.Modify, valve.ModifyDate.ToString("yyyy-MM-dd HH:mm:ss"), valve.ValveCode, valve.ValveName, valve.ValveId, valve.ControlScope);
                new AttachmentManager().AddList(list, valve.ValveId, valve.Create, valve.CreateDate, valve.GenreId);
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
        public ValveViewModel GetList(string where)
        {
            var valve = new ValveViewModel();
            var sql = "select * from waterservice.ValveView" + where;
            valve.List = new MySqlHelper().FindToList<Valve>(sql).ToList();
            valve.TotalCount = valve.List.Count;
            return valve;
        }
    }
}
