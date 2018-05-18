using System;
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
        public bool Add(UserInfo user, DrainageInfo drainage, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("insert into waterService.drainageInfo(DrainageCode,DrainageName,TypeId,GenreId,Caliber,Lat,Lon,`Create`,CreateDate) values('{0}','{1}',{2},{3},{4},{5},{6},'{7}','{8}');select @@IDENTITY;", drainage.DrainageCode, drainage.DrainageName, drainage.TypeId, drainage.GenreId, drainage.Caliber, drainage.Lat, drainage.Lon, user.Create, user.CreateDate);
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
            return id != 0;
        }
        public bool Update(UserInfo user, DrainageInfo valve, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            if (valve != null)
            {
                sb.AppendFormat("update waterService.drainageInfo set GenreId={0},TypeId={1},Caliber={2},Lat={3},Lon={4},Modify='{5}',ModifyDate='{6}',DrainageCode='{7}',DrainageName='{8}' where DrainageId={9};", valve.GenreId, valve.TypeId, valve.Caliber, valve.Lat, valve.Lon, valve.Modify, valve.ModifyDate, valve.DrainageCode, valve.DrainageName, valve.DrainageId);
            }
            new UserManage().UpDate_WaterService_UserInfo(user);
            new AttachmentManager().Update(list);
            return new MySqlHelper().ExcuteNonQuery(sb.ToString()) > 0;
        }
        public DrainageViewModel GetList(string where)
        {
            var valve = new DrainageViewModel();
            var sql = "select DrainageId,DrainageCode,DrainageName,Caliber,Lat,Lon,ui.UserId,ui.UserName,ui.UserAddress,ui.UserPhone,ui.Remark,ui.`Create`,ui.CreateDate,ui.Modify,ui.ModifyDate,gi.GenreId,gi.GenreName,ti.TypeId,ti.TypeName from  waterservice.drainageInfo va join waterservice.userinfo ui on ui.MeterId = va.DrainageId join waterservice.genreinfo gi on gi.GenreId = va.GenreId join waterservice.typeinfo ti on ti.TypeId = va.TypeId " + where;
            valve.List = new MySqlHelper().FindToList<Drainage>(sql).ToList();
            valve.TotalCount = valve.List.Count;
            return valve;
        }
    }
}
