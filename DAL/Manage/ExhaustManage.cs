using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;
using Model.ViewModel;
using Model.WaterService;

namespace DAL.Manage
{
    public class ExhaustManage
    {
        public bool Add(UserInfo user, ExhaustInfo exhaust, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("insert into waterService.exhaustInfo(ExhaustCode,ExhaustName,TypeId,GenreId,Caliber,Lat,Lon,`Create`,CreateDate) values('{0}','{1}',{2},{3},{4},{5},{6},'{7}','{8}');select @@IDENTITY;", exhaust.ExhaustCode, exhaust.ExhaustName, exhaust.TypeId, exhaust.GenreId, exhaust.Caliber, exhaust.Lat, exhaust.Lon, user.Create, user.CreateDate);
            var id = int.Parse(new MySqlHelper().ExecuteScalar(sb.ToString()).ToString());
            new UserManage().Add_WaterService_UserInfo(user, id);
            new AttachmentManager().AddList(list, id, user.Create, user.CreateDate, exhaust.GenreId);
            new MaintenanceManager().Add(new MaintenanceInfo()
            {
                MeterId = int.Parse(id.ToString()),
                GenreId = exhaust.GenreId,
                TypeId = exhaust.TypeId,
                Create = user.Create,
                CreateDate = DateTime.Now,
                InstallTime = DateTime.Now,
            });
            return id != 0;
        }
        public bool Update(UserInfo user, ExhaustInfo exhaust, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();

            if (exhaust != null)
            {
                sb.AppendFormat("update waterService.exhaustInfo set GenreId={0},TypeId={1},Caliber={2},Lat={3},Lon={4},Modify='{5}',ModifyDate='{6}',ExhaustCode='{7}',ExhaustName='{8}' where ExhaustId={9};", exhaust.GenreId, exhaust.TypeId, exhaust.Caliber, exhaust.Lat, exhaust.Lon, exhaust.Modify, exhaust.ModifyDate, exhaust.ExhaustCode, exhaust.ExhaustName, exhaust.ExhaustId);
            }
            new UserManage().UpDate_WaterService_UserInfo(user);
            new AttachmentManager().Update(list);
            return new MySqlHelper().ExcuteNonQuery(sb.ToString()) > 0;
        }
        public ExhaustViewModel GetList(string where)
        {
            var valve = new ExhaustViewModel();
            var sql = "select ExhaustId,ExhaustCode,ExhaustName,Caliber,Lat,Lon,ui.UserId,ui.UserName,ui.UserAddress,ui.UserPhone,ui.Remark,ui.`Create`,ui.CreateDate,ui.Modify,ui.ModifyDate,gi.GenreId,gi.GenreName,ti.TypeId,ti.TypeName from  waterservice.exhaustInfo va join waterservice.userinfo ui on ui.MeterId = va.ExhaustId join waterservice.genreinfo gi on gi.GenreId = va.GenreId join waterservice.typeinfo ti on ti.TypeId = va.TypeId " + where;
            valve.List = new MySqlHelper().FindToList<Exhaust>(sql).ToList();
            valve.TotalCount = valve.List.Count;
            return valve;
        }
    }
}
