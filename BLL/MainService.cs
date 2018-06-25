using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Model.ViewModel;
using YuanXin.Framework;
using DAL;
using DAL.Manage;
using Model.WaterService;

namespace BLL
{
    public static class MainService
    {
        public static List<MainViewModel> QueryList(MainQuery query)
        {
            var list = new List<MainViewModel>();
            var positionModel = DistanceHelper.FindNeighPosition(query.Longitude, query.Latitude, query.Distance);
            var sql = $" lon<={positionModel.MaxLat} and lon>={positionModel.MinLat} and lat>={positionModel.MaxLng} and lat<={positionModel.MinLng} ";

            var drainage = Task.Factory.StartNew(() => new MainManage().QueryList<DrainageInfo>(sql));
            var exhaust = Task.Factory.StartNew(() => new MainManage().QueryList<ExhaustInfo>(sql));
            var pipe = Task.Factory.StartNew(() => new MainManage().QueryList<PipeLineInfo>(sql));
            var sludge = Task.Factory.StartNew(() => new MainManage().QueryList<SludgeInfo>(sql));
            var valve = Task.Factory.StartNew(() => new MainManage().QueryList<ValveInfo>(sql));
            var water = Task.Factory.StartNew(() => new MainManage().QueryList<WaterMeterInfo>(sql));
            var fire = Task.Factory.StartNew(() => new MainManage().QueryList<FireFightingInfo>(sql));
            var genre = Task.Factory.StartNew(() => new GenreManager().GetList(""));
            var type = Task.Factory.StartNew(() => new TypeManager().GetList(""));
            Task.WaitAll(drainage, exhaust, pipe, sludge, valve, water, genre, type, fire);
            var g = genre.Result;
            var t = type.Result;
            var ids = new StringBuilder();
            var trackIds = new StringBuilder();
            drainage.Result.ForEach(item =>
            {
                list.Add(new MainViewModel()
                {
                    Id = item.DrainageId,
                    Code = item.DrainageCode,
                    Name = item.DrainageName,
                    Lat = item.Lat,
                    Lon = item.Lon,
                    GenreId = item.GenreId,
                    TypeId = item.TypeId,
                    Caliber = item.Caliber,
                    Create = item.Create,
                    CreateDate = item.CreateDate,
                    Status = item.Status,
                    Modify = item.Modify,
                    ModifyDate = item.ModifyDate,
                });
                ids.Append($"{item.DrainageId},");
            });
            exhaust.Result.ForEach(item =>
            {
                list.Add(new MainViewModel()
                {
                    Id = item.ExhaustId,
                    Code = item.ExhaustCode,
                    Name = item.ExhaustName,
                    Lat = item.Lat,
                    Lon = item.Lon,
                    GenreId = item.GenreId,
                    TypeId = item.TypeId,
                    Caliber = item.Caliber,
                    Create = item.Create,
                    CreateDate = item.CreateDate,
                    Status = item.Status,
                    Modify = item.Modify,
                    ModifyDate = item.ModifyDate
                });
                ids.Append($"{item.ExhaustId},");
            });
            sludge.Result.ForEach(item =>
            {
                list.Add(new MainViewModel()
                {
                    Id = item.SludgeId,
                    Code = item.SludgeCode,
                    Name = item.SludgeName,
                    Lat = item.Lat,
                    Lon = item.Lon,
                    GenreId = item.GenreId,
                    TypeId = item.TypeId,
                    Caliber = item.Caliber,
                    Create = item.Create,
                    CreateDate = item.CreateDate,
                    Status = item.Status,
                    Modify = item.Modify,
                    ModifyDate = item.ModifyDate
                });
                ids.Append($"{item.SludgeId},");
            });
            valve.Result.ForEach(item =>
            {
                list.Add(new MainViewModel()
                {
                    Id = item.ValveId,
                    Code = item.ValveCode,
                    Name = item.ValveName,
                    Lat = item.Lat,
                    Lon = item.Lon,
                    GenreId = item.GenreId,
                    TypeId = item.TypeId,
                    Caliber = item.Caliber,
                    Create = item.Create,
                    CreateDate = item.CreateDate,
                    Status = item.Status,
                    Modify = item.Modify,
                    ModifyDate = item.ModifyDate
                });
                ids.Append($"{item.ValveId},");
            });
            water.Result.ForEach(item =>
            {
                list.Add(new MainViewModel()
                {
                    Id = item.WaterId,
                    Code = item.WaterCode,
                    Name = item.WaterName,
                    Lat = item.Lat,
                    Lon = item.Lon,
                    GenreId = item.GenreId,
                    TypeId = item.TypeId,
                    Caliber = item.Caliber,
                    Create = item.Create,
                    CreateDate = item.CreateDate,
                    Status = item.Status,
                    Modify = item.Modify,
                    ModifyDate = item.ModifyDate
                });
                ids.Append($"{item.WaterMeterId},");
            });
            pipe.Result.ForEach(item =>
            {
                list.Add(new MainViewModel()
                {
                    Id = item.PipeLineId,
                    Code = item.PipeLineCode,
                    Name = item.PipeLineName,
                    GenreId = item.GenreId,
                    TypeId = item.TypeId,
                    Caliber = item.Caliber,
                    TrackId = item.TrackId,
                    Create = item.Create,
                    CreateDate = item.CreateDate,
                    Status = item.Status,
                    Modify = item.Modify,
                    ModifyDate = item.ModifyDate,
                    Lat = item.Lat,
                    Lon = item.Lon,
                    ModelName = item.ModelName,
                    ModelId = item.ModelId
                });
                ids.Append($"{item.PipeLineId},");
                trackIds.Append($"{item.PipeLineId},");
            });
            fire.Result.ForEach(item =>
            {
                list.Add(new MainViewModel()
                {
                    Id = item.FireFightingId,
                    Code = item.FireFightingCode,
                    Name = item.FireFightingName,
                    Lat = item.Lat,
                    Lon = item.Lon,
                    GenreId = item.GenreId,
                    TypeId = item.TypeId,
                    Caliber = item.Caliber,
                    Create = item.Create,
                    CreateDate = item.CreateDate,
                    Status = item.Status,
                    Modify = item.Modify,
                    ModifyDate = item.ModifyDate
                });
                ids.Append($"{item.FireFightingId},");
            });
            var userTask = Task.Factory.StartNew(() =>
            {
                if (ids.Length > 1)
                {
                    return new UserManage().QueryUserInfoListByMeterId(ids.ToString().TrimEnd(','));
                }
                else
                {
                    return new List<UserInfo>();
                }
            });
            var trackTask = Task.Factory.StartNew(() =>
              {
                  if (trackIds.Length > 1)
                  {
                      return new TrackManager().GetList(trackIds.ToString().TrimEnd(','));
                  }
                  else
                  {
                      return new List<TrackInfo>();
                  }
              });
            var attTask = Task.Factory.StartNew(() =>
            {
                if (ids.Length > 1)
                {
                    return new AttachmentManager().GetList($" where MeterId in ({ids.ToString().TrimEnd(',')}); ");
                }
                else
                {
                    return new List<AttachmentInfo>();
                }
            });
            Task.WaitAll(userTask, trackTask, attTask);
            var userList = userTask.Result;
            var trackList = trackTask.Result;
            var att = attTask.Result;
            list.ForEach(item =>
            {
                var gn = g.Find(p => p.GenreId == item.GenreId);
                if (gn != null)
                {
                    item.GenreName = gn.GenreName;
                }
                var tn = t.Find(p => p.TypeId == item.TypeId);
                if (tn != null)
                {
                    item.TypeName = tn.TypeName;
                }
                var user = userList.Find(p => p.MeterId == item.Id);
                if (user != null)
                {
                    item.Remark = user.Remark;
                    item.UserAddress = user.UserAddress;
                    item.UserName = user.UserName;
                    item.UserPhone = user.UserPhone;
                }
                if (item.GenreId == 1005)
                {
                    var track = trackList.Find(p => p.TrackId == item.TrackId);
                    if (track != null)
                    {
                        item.TrackInfo = track;
                    }
                }
                item.AttachmentList = att.FindAll(p => p.MeterId == item.Id);
            });
            return list;
        }
    }
}

