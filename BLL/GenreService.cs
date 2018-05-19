using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.ViewModel;
using Model.WaterService;

namespace BLL
{
    public class GenreService
    {
        public GenreViewModel GetList(SearchModel query)
        {
            var where = new StringBuilder();
            where.Append(" where 1=1 ");
            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Name))
                {
                    where.AppendFormat(" and  GenreName like '%{0}%'", query.Name);
                }
            }
            else
            {
                query = new SearchModel();
            }
            var v = new GenreViewModel();
            var data = new DAL.Manage.GenreManager().GetList(where.ToString());
            v.TotalCount = data.Count;
            v.List = data.Skip(query.PageIndex * query.PageSize).Take(query.PageSize).ToList();
            return v;
        }

        public bool AddInfo(GenreInfo genre)
        {
            return new DAL.Manage.GenreManager().AddInfo(genre);
        }

        public bool Update(GenreInfo genre)
        {
            return new DAL.Manage.GenreManager().Update(genre);
        }

        public Model.WaterService.GenreInfo QueryGenreInfo(int id)
        {
            return new DAL.Manage.GenreManager().QueryGenreInfo(id);
        }
    }
}
