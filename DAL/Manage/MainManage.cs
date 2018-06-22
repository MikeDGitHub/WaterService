using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;

namespace DAL
{
    public class MainManage
    {
        public List<T> QueryList<T>(string where) where T : class, new()
        {
            var t = typeof(T);
            var sql = $"select * from waterService.{t.Name} where {where}";
            return new MySqlHelper().FindToList<T>(sql).ToList();
        }
    }
}
