using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Manage;
using Model.ViewModel;
using Model.WaterService;

namespace BLL
{
    public class DrainageService
    {
        private readonly DrainageManager dal = new DrainageManager();
        public bool Add(UserInfo user, DrainageInfo drainage, List<AttachmentInfo> list)
        {
            return dal.Add(user, drainage, list);
        }
        public bool Update(UserInfo user, DrainageInfo drainage, List<AttachmentInfo> list)
        {
            return dal.Update(user, drainage, list);
        }
        public DrainageViewModel GetList(SearchModel query)
        {
            var where = new StringBuilder();

            if (query != null)
            {
                where = GenerateQuerySQL.GenerateQuery(query, typeof(Drainage).Name);
            }
            else
            {
                query = new SearchModel();
            }
            var v = dal.GetList(where.ToString());
            v.List = v.List.Skip(query.PageIndex * query.PageSize).Take(query.PageSize).ToList();
            var ids = new StringBuilder();
            where.Clear();
            v.List.ForEach(item =>
            {
                ids.AppendFormat("{0},", item.DrainageId);
            });
            if (ids.Length > 0)
            {
                where.AppendFormat(" where  MeterId in ({0})", ids.ToString().TrimEnd(','));
            }

            var att = new AttachmentManager().GetList(where.ToString());
            v.List.ForEach(item =>
            {
                item.AttachmentList = att.FindAll(p => p.MeterId == item.DrainageId);
            });
            return v;
        }
    }
}
