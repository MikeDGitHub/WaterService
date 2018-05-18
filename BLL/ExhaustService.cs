﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.ViewModel;
using Model.WaterService;

namespace BLL
{
    public class ExhaustService
    {
        public bool Add(Model.WaterService.UserInfo user, Model.WaterService.ExhaustInfo exhaust, List<Model.WaterService.AttachmentInfo> list)
        {
            return new DAL.Manage.ExhaustManage().Add(user, exhaust, list);
        }

        public bool Update(UserInfo user, ExhaustInfo exhaust, List<AttachmentInfo> list)
        {
            return new DAL.Manage.ExhaustManage().Update(user, exhaust, list);
        }

        public ExhaustViewModel GetList(QueryModel query)
        {
            var where = new StringBuilder();

            if (query != null)
            {
                where = GenerateQuerySQL.GenerateQuery(query);
            }
            else
            {
                query = new QueryModel();
            }
            var v = new DAL.Manage.ExhaustManage().GetList(where.ToString());
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
                var att = new DAL.Manage.AttachmentManager().GetList(where.ToString());
                v.List.ForEach(item =>
                {
                    item.AttachmentList = att.FindAll(p => p.MeterId == item.ExhaustId);
                });
            }
            return v;
        }
    }
}
