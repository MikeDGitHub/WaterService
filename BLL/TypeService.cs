using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.ViewModel;
using Model.WaterService;

namespace BLL
{
    public class TypeService
    {
        public TypeViewModel GetList(QueryModel query)
        {
            var where = new StringBuilder();
            where.Append(" where 1=1 ");
            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Name))
                {
                    where.AppendFormat(" and  TypeName like '%{0}%'", query.Name);
                }
            }
            else
            {
                query = new QueryModel();
            }
            var v = new TypeViewModel();
            var data = new DAL.Manage.TypeManager().GetList(where.ToString());
            v.TotalCount = data.Count;
            v.List = data.Skip(query.PageIndex * query.PageSize).Take(query.PageSize).ToList();
            return v;
        }

        public bool AddInfo(TypeInfo typeInfo)
        {
            return new DAL.Manage.TypeManager().AddInfo(typeInfo);
        }

        public bool Update(TypeInfo typeInfo)
        {
            return new DAL.Manage.TypeManager().Update(typeInfo);
        }

        public Model.WaterService.TypeInfo QueryTypeInfo(int id)
        {
            return new DAL.Manage.TypeManager().QueryTypeInfo(id);
        }
    }
}
