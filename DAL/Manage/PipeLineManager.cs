using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;
using Model.ViewModel;
using Model.WaterService;

namespace DAL.Manage
{
    public class PipeLineManager
    {
        public bool Add(UserInfo user, PipeLineInfo pipeLine, TrackInfo track, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            var id = new TrackManager().Add(track, user.Create, user.CreateDate);
            sb.AppendFormat("insert into WaterService.PipeLineInfo (PipeLineName,TrackId,Acreage,Caliber,Remark,`Create`,CreateDate,TypeId,GenreId) values('{0}',{1},{2},{3},'{4}','{5}','{6}',{7},{8});", pipeLine.PipeLineName, id, pipeLine.Acreage, pipeLine.Caliber, user.Remark, user.Create, user.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), pipeLine.TypeId, pipeLine.GenreId);
            new UserManage().Add_WaterService_UserInfo(user, id);
            new AttachmentManager().AddList(list, id, user.Create, user.CreateDate, pipeLine.GenreId);
            new MaintenanceManager().Add(new MaintenanceInfo()
            {
                MeterId = int.Parse(id.ToString()),
                GenreId = pipeLine.GenreId,
                TypeId = pipeLine.TypeId,
                Create = user.Create,
                CreateDate = DateTime.Now,
                InstallTime = DateTime.Now,
            });
            return new MySqlHelper().ExcuteNonQuery(sb.ToString()) > 0;
        }

        public bool Update(UserInfo user, PipeLineInfo pipeLine, TrackInfo track, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();

            if (pipeLine != null)
            {
                sb.AppendFormat("update WaterService.PipeLineInfo set PipeLineName='{0}',Acreage={1} ,Caliber={2}, Modify='{3}',ModifyDate='{4}',status={6} where PipeLineId={5};", pipeLine.PipeLineName, pipeLine.Acreage, pipeLine.Caliber, pipeLine.Modify, pipeLine.ModifyDate.ToString("yyyy-MM-dd HH:mm:ss"), pipeLine.PipeLineId, pipeLine.Status);
            }

            new TrackManager().UpDate(track);
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
        public PipeLineViewModel GetList(string where)
        {
            var valve = new PipeLineViewModel();
            var sql = "select PipeLineId,PipeLineCode,PipeLineName,TrackId,Caliber,Acreage,ui.UserId,ui.UserName,ui.UserAddress,ui.UserPhone,ui.Remark,ui.`Create`,ui.CreateDate,ui.Modify,ui.ModifyDate,gi.GenreId,gi.GenreName,ti.TypeId,ti.TypeName from  waterservice.PipeLineInfo va join waterservice.userinfo ui on ui.MeterId = va.PipeLineId join waterservice.genreinfo gi on gi.GenreId = va.GenreId join waterservice.typeinfo ti on ti.TypeId = va.TypeId " + where;
            valve.List = new MySqlHelper().FindToList<PipeLine>(sql).ToList();
            valve.TotalCount = valve.List.Count;
            return valve;

        }
    }
}
