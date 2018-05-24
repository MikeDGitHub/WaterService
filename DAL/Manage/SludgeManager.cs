using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;
using Model.ViewModel;
using Model.WaterService;

namespace DAL.Manage
{
    public class SludgeManager
    {
        public bool Add(UserInfo user, SludgeInfo sludge, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("insert into WaterService.SludgeInfo(sludgeCode,sludgeName,TypeId,GenreId,Caliber,Lat,Lon,`Create`,CreateDate) values('{0}','{1}',{2},{3},{4},{5},{6},'{7}','{8}');select @@IDENTITY;", sludge.SludgeCode, sludge.SludgeName, sludge.TypeId, sludge.GenreId, sludge.Caliber, sludge.Lat, sludge.Lon, user.Create, user.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"));
            var id = int.Parse(new MySqlHelper().ExecuteScalar(sb.ToString()).ToString());
            new UserManage().Add_WaterService_UserInfo(user, id);
            new AttachmentManager().AddList(list, id, user.Create, user.CreateDate, sludge.GenreId);
            new MaintenanceManager().Add(new MaintenanceInfo()
            {
                MeterId = int.Parse(id.ToString()),
                GenreId = sludge.GenreId,
                TypeId = sludge.TypeId,
                Create = user.Create,
                CreateDate = DateTime.Now,
                InstallTime = DateTime.Now,
            });
            return id != 0;
        }
        public bool Update(UserInfo user, SludgeInfo sludge, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            if (sludge != null)
            {
                sb.AppendFormat("update WaterService.SludgeInfo set GenreId={0},TypeId={1},Caliber={2},Lat={3},Lon={4},Modify='{5}',ModifyDate='{6}',SludgeCode='{7}',SludgeName='{8}' where SludgeId={9};", sludge.GenreId, sludge.TypeId, sludge.Caliber, sludge.Lat, sludge.Lon, sludge.Modify, sludge.ModifyDate.ToString("yyyy-MM-dd HH:mm:ss"), sludge.SludgeCode, sludge.SludgeName, sludge.SludgeId);
            }
            new UserManage().UpDate_WaterService_UserInfo(user);
            new AttachmentManager().Update(list);
            if (sb.Length > 1)
            {
                return new MySqlHelper().ExcuteNonQuery(sb.ToString()) > 0;
            }
            else
            {
                return false;
            }

        }
        public SludgeViewModel GetList(string where)
        {
            var sludge = new SludgeViewModel();
            var sql = "select SludgeId,SludgeCode,SludgeName,Caliber,Lat,Lon,ui.UserId,ui.UserName,ui.UserAddress,ui.UserPhone,ui.Remark,ui.`Create`,ui.CreateDate,ui.Modify,ui.ModifyDate,gi.GenreId,gi.GenreName,ti.TypeId,ti.TypeName from  waterservice.sludgeinfo va join waterservice.userinfo ui on ui.MeterId = va.sludgeId join waterservice.genreinfo gi on gi.GenreId = va.GenreId join waterservice.typeinfo ti on ti.TypeId = va.TypeId " + where;
            sludge.List = new MySqlHelper().FindToList<Sludge>(sql).ToList();
            sludge.TotalCount = sludge.List.Count;
            return sludge;
        }
    }
}
