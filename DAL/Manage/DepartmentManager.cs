using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using DAL.Helper;
using Model.Oauth;

namespace DAL.Manage
{
    public class DepartmentManager
    {
        public bool Add(DepartmentInfo dep)
        {
            var sql =
                "insert into oauth.departmentinfo (DepName,ParentId,`create`,createDate)values (@DepName,@ParentId,@create,@createDate);";
            var param = new DynamicParameters();
            param.Add("@depName", dep.DepName, DbType.String);
            param.Add("@ParentId", dep.ParentId, DbType.Int32);
            param.Add("@create", dep.Create, DbType.String);
            param.Add("@createDate", dep.CreateDate, DbType.DateTime);
            return new MySqlHelper().ExcuteNonQuery(sql, param) > 0;
        }

        public bool Update(DepartmentInfo dep)
        {
            var sql =
                "update oauth.departmentinfo set DepName=@DepName,ParentId =@ParentId,modify=@modify,modifyDate=@modifyDate,status=@status where depId=@depId;";
            var param = new DynamicParameters();
            param.Add("@depName", dep.DepName, DbType.String);
            param.Add("@ParentId", dep.ParentId, DbType.Int32);
            param.Add("@depId", dep.DepId, DbType.Int32);
            param.Add("@modify", dep.Modify, DbType.String);
            param.Add("@modifyDate", dep.ModifyDate, DbType.DateTime);
            param.Add("@status", dep.Status, DbType.Int32);
            return new MySqlHelper().ExcuteNonQuery(sql, param) > 0;
        }

        public List<DepartmentInfo> GetList(int parentId = 0)
        {
            var sql = "select * from oauth.departmentinfo where ParentId=" + parentId;
            return new MySqlHelper().FindToList<DepartmentInfo>(sql).ToList();
        }

        public bool CheckDepName(string depName)
        {
            var sql = string.Format("select * from oauth.departmentinfo where DepName='{0}'", depName);
            return new MySqlHelper().FindToList<DepartmentInfo>(sql).ToList().Any();
        }
        public DepartmentInfo GetModelById(int id)
        {
            var sql = "select * from oauth.departmentinfo where depId=" + id;
            return new MySqlHelper().FindOne<DepartmentInfo>(sql);
        }
    }
}
