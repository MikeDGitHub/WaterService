using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;
using Model.WaterService;
using Newtonsoft.Json;

namespace DAL.Manage
{
    public class TrackManager
    {
        public TrackInfo GetById(int id)
        {
            var sql = $"select * from WaterService.TrackInfo where TrackId={id}";
            var t = new TrackInfo();
            var dt = new MySqlHelper().GetDataTable(sql);
            var obj = new object();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                t.TrackId = id;

                obj = row["Modify"];
                if (obj != DBNull.Value)
                {
                    t.Modify = row["Modify"].ToString();
                }
                obj = row["ModifyDate"];
                if (obj != DBNull.Value)
                {
                    t.ModifyDate = DateTime.Parse(obj.ToString());
                }
                obj = row["StartLat"];
                if (obj != DBNull.Value)
                {
                    t.StartLat = Double.Parse(obj.ToString());
                }
                obj = row["StartLon"];
                if (obj != DBNull.Value)
                {
                    t.StartLon = Double.Parse(obj.ToString());
                }
                obj = row["EndLat"];
                if (obj != DBNull.Value)
                {
                    t.EndLat = Double.Parse(obj.ToString());
                }
                obj = row["EndLon"];
                if (obj != DBNull.Value)
                {
                    t.EndLon = Double.Parse(obj.ToString());
                }
                obj = row["Create"];
                if (obj != DBNull.Value)
                {
                    t.Create = obj.ToString();
                }
                obj = row["CreateDate"];
                if (obj != DBNull.Value)
                {
                    t.CreateDate = DateTime.Parse(obj.ToString());
                }
                obj = row["Coordinate"];
                if (obj != DBNull.Value)
                {
                    t.Coordinate = JsonConvert.DeserializeObject<List<Coordinate>>(obj.ToString());
                }
            }
            return t;
        }

        public List<TrackInfo> GetList(string ids)
        {
            var sql = $"select * from WaterService.TrackInfo where TrackId in ({ids});";
            var list = new List<TrackInfo>();
            var dt = new MySqlHelper().GetDataTable(sql);
            var obj = new object();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var t = new TrackInfo();
                var row = dt.Rows[i];
                obj = row["TrackId"];
                if (obj != DBNull.Value)
                {
                    t.TrackId = int.Parse(row["Modify"].ToString());
                }
                obj = row["Modify"];
                if (obj != DBNull.Value)
                {
                    t.Modify = row["Modify"].ToString();
                }
                obj = row["ModifyDate"];
                if (obj != DBNull.Value)
                {
                    t.ModifyDate = DateTime.Parse(obj.ToString());
                }
                obj = row["StartLat"];
                if (obj != DBNull.Value)
                {
                    t.StartLat = Double.Parse(obj.ToString());
                }
                obj = row["StartLon"];
                if (obj != DBNull.Value)
                {
                    t.StartLon = Double.Parse(obj.ToString());
                }
                obj = row["EndLat"];
                if (obj != DBNull.Value)
                {
                    t.EndLat = Double.Parse(obj.ToString());
                }
                obj = row["EndLon"];
                if (obj != DBNull.Value)
                {
                    t.EndLon = Double.Parse(obj.ToString());
                }
                obj = row["Create"];
                if (obj != DBNull.Value)
                {
                    t.Create = obj.ToString();
                }
                obj = row["CreateDate"];
                if (obj != DBNull.Value)
                {
                    t.CreateDate = DateTime.Parse(obj.ToString());
                }
                obj = row["Coordinate"];
                if (obj != DBNull.Value)
                {
                    t.Coordinate = JsonConvert.DeserializeObject<List<Coordinate>>(obj.ToString());
                }
                list.Add(t);
            }
            return list;
        }
        public int Add(TrackInfo track, string create, DateTime createDate)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("insert into WaterService.TrackInfo (Coordinate,StartLat,StartLon,EndLat,EndLon,`Create`,CreateDate) values('{0}',{1},{2},{3},{4},'{5}','{6}');select @@IDENTITY;", JsonConvert.SerializeObject(track.Coordinate), track.StartLat, track.StartLon, track.EndLat, track.EndLon, create, createDate.ToString("yyyy-MM-dd HH:mm:ss"));
            return int.Parse(new MySqlHelper().ExecuteScalar(sb.ToString()).ToString());
        }

        public bool UpDate(TrackInfo track)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("update WaterService.TrackInfo set Coordinate='{0}',StartLat={1},StartLon={2},EndLat={3},EndLon={4} where TrackId={5}", JsonConvert.SerializeObject(track.Coordinate), track.StartLat, track.StartLon, track.EndLon, track.EndLat, track.TrackId);
            return new MySqlHelper().ExcuteNonQuery(sb.ToString()) > 0;
        }
    }
}
