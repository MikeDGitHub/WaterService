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
                where.AppendFormat(" and  UserAddress like '%{0}%'", query.Address);

                if (Justice1(query.Address))
                {
                    where.AppendFormat(" or  code like '%{0}%' ", query.Address);
                }
            }
            if (query.GenreId > 0)
            {
                where.AppendFormat("  and GenreId = {0}", query.GenreId);
            }
            if (query.TypeId > 0)
            {
                where.AppendFormat("  and TypeId = {0}", query.TypeId);
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
        static bool Justice1(string text)
        {
            var flag = true;
            foreach (char t in text)
            {
                if (t > 127)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
    }
}
