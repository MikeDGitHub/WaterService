using System;
using System.Collections.Generic;
using System.Text;
using DAL.Helper;
using Model.WaterService;

namespace DAL.Manage
{
    public class TrackManager
    {
        public TrackInfo GetById(int id)
        {
            return new MySqlHelper().FindOne<TrackInfo>("select * from WaterService.TrackInfo where TrackId=" + id);
        }

        public int Add(TrackInfo track, string create, DateTime createDate)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("insert into WaterService.TrackInfo (Coordinate,StartLat,StartLon,EndLat,EndLon,`Create`,CreateDate) values('{0}',{1},{2},{3},{4},'{5}','{6}');select @@IDENTITY;", track.Coordinate, track.StartLat, track.StartLon, track.EndLat, track.EndLon, create, createDate.ToString("yyyy-MM-dd HH:mm:ss"));
            return int.Parse(new MySqlHelper().ExecuteScalar(sb.ToString()).ToString());
        }

        public bool UpDate(TrackInfo track)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("update WaterService.TrackInfo set Coordinate='{0}',StartLat={1},StartLon={2},EndLat={3},EndLon={4} where TrackId={5}", track.Coordinate, track.StartLat, track.StartLon, track.EndLon, track.EndLat, track.TrackId);
            return new MySqlHelper().ExcuteNonQuery(sb.ToString()) > 0;
        }
    }
}
