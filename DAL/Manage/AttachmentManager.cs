using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.WaterService;
using MySql.Data.MySqlClient;
using MySqlHelper = DAL.Helper.MySqlHelper;

namespace DAL.Manage
{
    public class AttachmentManager
    {
        public List<AttachmentInfo> GetList(string where)
        {
            var sql = "select * from waterservice.attachmentinfo " + where;
            return new MySqlHelper().FindToList<AttachmentInfo>(sql).ToList();
        }

        public bool Add(AttachmentInfo attachment)
        {
            var sql = string.Format("insert into waterService.attachmentinfo (MeterId,ImgUrl,`Create`,CreateDate,GenreId) values({0},'{1}','{2}','{3}',{4});", attachment.MeterId, attachment.ImgUrl, attachment.Create, attachment.Create, attachment.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), attachment.GenreId);
            return new MySqlHelper().ExcuteNonQuery(sql) > 0;
        }


        public bool AddList(List<AttachmentInfo> list, object id, string Create, DateTime CreateDate, int GenreId)
        {
            var sb = new StringBuilder();
            list?.ForEach(item =>
            {
                sb.AppendFormat("insert into waterService.attachmentInfo (MeterId,ImgUrl,`Create`,CreateDate,GenreId) values({0},'{1}','{2}','{3}',{4});", id, item.ImgUrl, Create, CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), GenreId);
            });
            return new MySqlHelper().ExcuteNonQuery(sb.ToString()) > 0;
        }

        public bool Update(AttachmentInfo attachment)
        {
            var sql = string.Format("update waterService.attachmentInfo set ImgUrl='{0}',genreId={1},modify='{2}',modifyDate='{3}' where AttachmentId={4};", attachment.ImgUrl, attachment.GenreId, attachment.Modify, attachment.ModifyDate.ToString("yyyy-MM-dd HH:mm:ss"), attachment.AttachmentId);
            return new MySqlHelper().ExcuteNonQuery(sql) > 0;
        }

        public bool Update(List<AttachmentInfo> list)
        {
            var sb = new StringBuilder();
            list?.ForEach(item =>
            {
                sb.AppendFormat("update waterService.attachmentInfo set ImgUrl='{0}',genreId={1},modify='{2}',modifyDate='{3}' where AttachmentId={4};", item.ImgUrl, item.GenreId, item.Modify, item.ModifyDate.ToString("yyyy-MM-dd HH:mm:ss"), item.AttachmentId, item);
            });
            if (sb.Length > 1)
            {
                return new MySqlHelper().ExcuteNonQuery(sb.ToString()) > 0;
            }
            else
            {
                return false;
            }

        }
    }
}
