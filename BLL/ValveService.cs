using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Manage;
using Model.ViewModel;
using Model.WaterService;

namespace BLL
{
    public class ValveService
    {
        private readonly ValveManage _dal = new DAL.Manage.ValveManage();
        public int Add(Model.WaterService.UserInfo user, Model.WaterService.ValveInfo valve, List<Model.WaterService.AttachmentInfo> list)
        {
            return _dal.Add(user, valve, list);
        }
        public bool Update(UserInfo user, ValveInfo valve, List<AttachmentInfo> list)
        {
            return _dal.Update(user, valve, list);
        }

        public ValveViewModel GetList(SearchModel query)
        {
            var where = new StringBuilder();
            if (query != null)
            {
                where = GenerateQuerySQL.GenerateQuery(query, typeof(Valve).Name);
            }
            else
            {
                query = new SearchModel();
            }
            var v = _dal.GetList(where.ToString());
            v.List = v.List.Skip(query.PageIndex * query.PageSize).Take(query.PageSize).ToList();
            var ids = new StringBuilder();
            where.Clear();
            v.List.ForEach(item =>
            {
                ids.AppendFormat("{0},", item.ValveId);
            });
            if (ids.Length > 0)
            {
                where.AppendFormat(" where MeterId in ({0})", ids.ToString().TrimEnd(','));
                var att = new AttachmentManager().GetList(where.ToString());
                v.List.ForEach(item =>
                {
                    item.AttachmentList = att.FindAll(p => p.MeterId == item.ValveId);
                });
            }
            return v;
        }
    }
}

