using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;
using Model.WaterService;

namespace DAL.Manage
{
    public class GenreManager
    {
        public List<GenreInfo> GetList(string where)
        {
            var sql = "select GenreId  , GenreName ,Status,`Create`,CreateDate,Modify,ModifyDate from waterService.genreInfo  " + where;
            return new MySqlHelper().FindToList<GenreInfo>(sql).ToList();
        }

        public bool AddInfo(GenreInfo genre)
        {
            var sql = string.Format("insert into WaterService.GenreInfo (GenreName,Status,`Create`) values ('{0}',1,'{1}')", genre.GenreName, genre.Create);
            return new MySqlHelper().ExcuteNonQuery(sql) > 0;
        }

        public bool Update(GenreInfo genre)
        {
            var sql = string.Format("update WaterService.GenreInfo set GenreName='{0}',Status={1},Modify='{2}',ModifyDate='{3}' where GenreId={4}", genre.GenreName, genre.Status, genre.Modify, genre.ModifyDate.ToString("yyyy-MM-dd HH:mm:ss"), genre.GenreId);
            return new MySqlHelper().ExcuteNonQuery(sql) > 0;
        }
        public Model.WaterService.GenreInfo QueryGenreInfo(int id)
        {
            return new MySqlHelper().FindOne<GenreInfo>("select * from WaterService.GenreInfo where GenreId=" + id);
        }
    }
}
