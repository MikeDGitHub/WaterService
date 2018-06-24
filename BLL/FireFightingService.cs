using DAL.Manage;
using System;
using System.Collections.Generic;
using System.Text;
using Model.WaterService;
using Model.ViewModel;
using System.Linq;

namespace BLL
{
    public class FireFightingService
    {
        private readonly FireFightingManage dal = new FireFightingManage();
        public bool Add(Model.WaterService.UserInfo user, Model.WaterService.FireFightingInfo fireFightingInfo, List<Model.WaterService.AttachmentInfo> list)
        {
            return dal.Add(user, fireFightingInfo, list);
        }
        public bool Update(UserInfo user, FireFightingInfo fireFightingInfo, List<AttachmentInfo> list)
        {
            return dal.Update(user, fireFightingInfo, list);
        }
        public FireFightingViewModel GetList(SearchModel query)
        {
            var where = new StringBuilder();
            if (query != null)
            {
                where = GenerateQuerySQL.GenerateQuery(query, typeof(FireFighting).Name);
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
                ids.AppendFormat("{0},", item.FireFightingId);
            });
            if (ids.Length > 0)
            {
                where.AppendFormat(" where MeterId in ({0})", ids.ToString().TrimEnd(','));
                var att = new AttachmentManager().GetList(where.ToString());
                v.List.ForEach(item =>
                {
                    item.AttachmentList = att.FindAll(p => p.MeterId == item.FireFightingId);
                });
            }
            return v;
        }
    }
}
