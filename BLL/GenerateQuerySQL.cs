using System;
using System.Collections.Generic;
using System.Text;
using Model.ViewModel;

namespace BLL
{
    public static class GenerateQuerySQL
    {
        public static StringBuilder GenerateQuery(SearchModel query)
        {
            var where = new StringBuilder();
            where.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(query.Address))
            {
                where.AppendFormat(" and  ui.UserAddress like '%{0}%'", query.Address);
            }
            if (query.GenreId > 0)
            {
                where.AppendFormat("  and gi.GenreId = {0}", query.GenreId);
            }
            if (query.TypeId > 0)
            {
                where.AppendFormat("  and ti.TypeId = {0}", query.TypeId);
            }
            if (!string.IsNullOrEmpty(query.StartAddress))
            {
                where.AppendFormat(" and  StartAddress like '%{0}%'", query.StartAddress);

            }
            if (!string.IsNullOrEmpty(query.EndAddress))
            {
                where.AppendFormat(" and  EndAddress like '%{0}%'", query.EndAddress);
            }
            return where;
        }
    }
}
