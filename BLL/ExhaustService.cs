using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Manage;
using Model.ViewModel;
using Model.WaterService;

namespace BLL
{
    public class ExhaustService
    {
        private readonly ExhaustManage dal = new ExhaustManage();
        public bool Add(Model.WaterService.UserInfo user, Model.WaterService.ExhaustInfo exhaust, List<Model.WaterService.AttachmentInfo> list)
        {
            return dal.Add(user, exhaust, list);
        }

        public bool Update(UserInfo user, ExhaustInfo exhaust, List<AttachmentInfo> list)
        {
            return dal.Update(user, exhaust, list);
        }

        public ExhaustViewModel GetList(SearchModel query)
        {
            var where = new StringBuilder();

            if (query != null)
            {
                where = GenerateQuerySQL.GenerateQuery(query, typeof(Exhaust).Name);
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
                ids.AppendFormat("{0},", item.ExhaustId);
            });
            if (ids.Length > 0)
            {
                where.AppendFormat(" where MeterId in ({0}) ", ids.ToString().TrimEnd(','));
                var att = new AttachmentManager().GetList(where.ToString());
                v.List.ForEach(item =>
                {
                    item.AttachmentList = att.FindAll(p => p.MeterId == item.ExhaustId);
                });
            }
            return v;
        }
    }
}
