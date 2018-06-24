using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Manage;
using Model.ViewModel;
using Model.WaterService;

namespace BLL
{
    public class TypeService
    {
        private readonly TypeManager dal = new TypeManager();
        public TypeViewModel GetList(SearchModel query)
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
                query = new SearchModel();
            }
            var v = new TypeViewModel();
            var data = dal.GetList(where.ToString());
            v.TotalCount = data.Count;
            v.List = data.Skip(query.PageIndex * query.PageSize).Take(query.PageSize).ToList();
            return v;
        }

        public bool AddInfo(TypeInfo typeInfo)
        {
            return dal.AddInfo(typeInfo);
        }

        public bool Update(TypeInfo typeInfo)
        {
            return dal.Update(typeInfo);
        }

        public Model.WaterService.TypeInfo QueryTypeInfo(int id)
        {
            return dal.QueryTypeInfo(id);
        }
    }
}
