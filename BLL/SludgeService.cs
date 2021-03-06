﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Manage;
using Model.ViewModel;
using Model.WaterService;

namespace BLL
{
    public class SludgeService
    {
        private readonly SludgeManager dal = new SludgeManager();
        public int Add(UserInfo user, SludgeInfo sludge, List<AttachmentInfo> list)
        {
            return dal.Add(user, sludge, list);
        }

        public bool Update(UserInfo user, SludgeInfo sludge, List<AttachmentInfo> list)
        {
            return dal.Update(user, sludge, list);
        }

        public SludgeViewModel GetList(SearchModel query)
        {
            var where = new StringBuilder();
            if (query != null)
            {
                where = GenerateQuerySQL.GenerateQuery(query, typeof(Sludge).Name);
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
                ids.AppendFormat("{0},", item.SludgeId);
            });
            if (ids.Length > 0)
            {

                where.AppendFormat(" where MeterId in ({0}) ", ids.ToString().TrimEnd(','));
                var att = new AttachmentManager().GetList(where.ToString());
                v.List.ForEach(item =>
                {
                    item.AttachmentList = att.FindAll(p => p.MeterId == item.SludgeId);
                });
            }
            return v;
        }
    }
}
