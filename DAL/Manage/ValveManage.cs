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
        public bool Add(UserInfo user, ValveInfo valve, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("insert into WaterService.ValveInfo(ValveCode,ValveName,TypeId,GenreId,Caliber,Lat,Lon,`Create`,CreateDate) values('{0}','{1}',{2},{3},{4},{5},{6},'{7}','{8}');select @@IDENTITY;", valve.ValveCode, valve.ValveName, valve.TypeId, valve.GenreId, valve.Caliber, valve.Lat, valve.Lon, user.Create, user.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"));
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
            return id != 0;
        }

        //public bool Add1<T>(UserInfo user, T t, List<AttachmentInfo> list)
        //{
        //    var infoType = typeof(T);
        //    var obj = JObject.Parse(JsonConvert.SerializeObject(t));
        //    var sql = "insert into WaterService.$0$ ($1$,$2$,$3$,$4$,$5$,$6$,$7$,$8$,`$9$`,$10$)values('$11$','$12$',$13$,$14$,$15$,$16$,$17$,$18$,'$19$','$20$');select @@IDENTITY";
        //    var GenreId = 0;
        //    for (int i = 1; i < infoType.GetProperties().Length; i++)
        //    {
        //        sql = sql.Replace(string.Format("${0}$", i), infoType.GetProperties()[i].Name);
        //        sql = sql.Replace(string.Format("${0}$", i + 10), obj[infoType.GetProperties()[i].Name].Value<string>());
        //        if (infoType.GetProperties()[i].Name == "GenreId")
        //        {
        //            GenreId = obj[infoType.GetProperties()[i].Name].Value<int>();
        //        }
        //    }
        //    sql = sql.Replace("$0$", infoType.Name);
        //    var id = new MySqlHelper().ExecuteScalar(sql);
        //    var sb = new StringBuilder();
        //    sb.AppendFormat("insert into WaterService.UserInfo(UserName,UserAddress,UserPhone,MeterId,Remark,`Create`,CreateDate) values('{0}','{1}','{2}',{6},'{3}','{4}','{5}');", user.UserName, user.UserAddress, user.UserPhone, user.Remark, user.Create, user.CreateDate, id);
        //    list?.ForEach(item =>
        //    {
        //        sb.AppendFormat("insert into WaterService.AttachmentInfo (MeterId,ImgUrl,`Create`,CreateDate,GenreId) values({0},'{1}','{2}','{3}',{4});", id, item.ImgUrl, user.Create, user.CreateDate, GenreId);
        //    });
        //    sb.AppendFormat("insert into WaterService.MaintenanceInfo (MeterId,GenreId,InstallTime,`Create`,CreateDate) values ({0},{1},'{2}','{3}','{4}');", id, GenreId, DateTime.Now, user.Create, user.CreateDate);
        //    return new MySqlHelper().ExcuteNonQuery(sb.ToString()) > 0;
        //}

        public bool Update(UserInfo user, ValveInfo valve, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            if (valve != null)
            {
                sb.AppendFormat("update WaterService.ValveInfo set GenreId={0},TypeId={1},Caliber={2},Lat={3},Lon={4},Modify='{5}',ModifyDate='{6}',ValveCode='{7}',ValveName='{8}' where ValveId={9};", valve.GenreId, valve.TypeId, valve.Caliber, valve.Lat, valve.Lon, valve.Modify, valve.ModifyDate.ToString("yyyy-MM-dd HH:mm:ss"), valve.ValveCode, valve.ValveName, valve.ValveId);
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
