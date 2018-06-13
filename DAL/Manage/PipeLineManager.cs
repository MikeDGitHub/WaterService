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
            sb.AppendFormat("insert into WaterService.PipeLineInfo (PipeLineName,TrackId,Caliber,Remark,`Create`,CreateDate,TypeId,GenreId,StartAddress,EndAddress,PipeLineCode,ModelId,ModelName,Acreage) values('{0}',{1},{2},'{3}','{4}','{5}',{6},{7},'{8}','{9}','{10}',{11},'{12}',{13});select @@IDENTITY;", pipeLine.PipeLineName, id, pipeLine.Caliber, user.Remark, user.Create, user.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), pipeLine.TypeId, pipeLine.GenreId, pipeLine.StartAddress, pipeLine.EndAddress, pipeLine.PipeLineCode, pipeLine.ModelId, pipeLine.ModelName, pipeLine.Acreage);
            var pid = int.Parse(new MySqlHelper().ExecuteScalar(sb.ToString()).ToString());
            new UserManage().Add_WaterService_UserInfo(user, pid);
            new AttachmentManager().AddList(list, pid, user.Create, user.CreateDate, pipeLine.GenreId);
            new MaintenanceManager().Add(new MaintenanceInfo()
            {
                MeterId = pid,
                GenreId = pipeLine.GenreId,
                TypeId = pipeLine.TypeId,
                Create = user.Create,
                CreateDate = DateTime.Now,
                InstallTime = DateTime.Now,
            });
            return pid != 0;
        }

        public bool Update(UserInfo user, PipeLineInfo pipeLine, TrackInfo track, List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();

            if (pipeLine != null)
            {
                sb.AppendFormat("update WaterService.PipeLineInfo set PipeLineName='{0}' ,Caliber={1}, Modify='{2}',ModifyDate='{3}',StartAddress='{5}',EndAddress='{6}' where PipeLineId={4};", pipeLine.PipeLineName, pipeLine.Caliber, pipeLine.Modify, pipeLine.ModifyDate.ToString("yyyy-MM-dd HH:mm:ss"), pipeLine.PipeLineId, pipeLine.StartAddress, pipeLine.EndAddress);
                new AttachmentManager().AddList(list, pipeLine.PipeLineId, pipeLine.Create, DateTime.Now, pipeLine.GenreId);
            }

            new TrackManager().UpDate(track);
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
        public PipeLineViewModel GetList(string where)
        {
            var pipeLine = new PipeLineViewModel();
            var sql = " select * from waterservice.PipeLineView " + where;
            pipeLine.List = new MySqlHelper().FindToList<PipeLine>(sql).ToList();
            pipeLine.TotalCount = pipeLine.List.Count;
            return pipeLine;

        }
    }
}
