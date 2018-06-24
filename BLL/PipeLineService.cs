using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Manage;
using Model.ViewModel;
using Model.WaterService;

namespace BLL
{
    public class PipeLineService
    {
        private readonly PipeLineManager dal = new PipeLineManager();
        public bool Add(UserInfo user, PipeLineInfo pipeLine, TrackInfo track, List<AttachmentInfo> list)
        {
            return dal.Add(user, pipeLine, track, list);
        }

        public bool Update(UserInfo user, PipeLineInfo pipeLine, TrackInfo track, List<AttachmentInfo> list)
        {
            return dal.Update(user, pipeLine, track, list);
        }

        public PipeLineViewModel GetList(SearchModel query)
        {
            var where = new StringBuilder();

            if (query != null)
            {
                where = GenerateQuerySQL.GenerateQuery(query, typeof(PipeLine).Name);
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
                ids.AppendFormat("{0},", item.PipeLineId);
                item.TrackInfo = new DAL.Manage.TrackManager().GetById(item.TrackId);

            });
            if (ids.Length > 0)
            {
                where.AppendFormat(" where MeterId in ({0})", ids.ToString().TrimEnd(','));
                var att = new AttachmentManager().GetList(where.ToString());
                v.List.ForEach(item =>
                {
                    item.AttachmentList = att.FindAll(p => p.MeterId == item.PipeLineId);
                });
            }
            return v;
        }
    }
}
