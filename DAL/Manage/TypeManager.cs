using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;
using Model.WaterService;

namespace DAL.Manage
{
    public class TypeManager
    {
        public List<TypeInfo> GetList(string where)
        {
            var sql = "select TypeId  , TypeName ,Status,`Create`,CreateDate,Modify,ModifyDate from WaterService.TypeInfo " + where;
            return new MySqlHelper().FindToList<TypeInfo>(sql).ToList();
        }

        public bool AddInfo(TypeInfo typeInfo)
        {
            var sql = string.Format("insert into WaterService.typeInfo (TypeName,Status,`Create`) values ('{0}',{2},'{1}')", typeInfo.TypeName, typeInfo.Create, typeInfo.Status);
            return new MySqlHelper().ExcuteNonQuery(sql) > 0;
        }

        public bool Update(TypeInfo typeInfo)
        {
            var sql = string.Format("update WaterService.typeInfo set TypeName='{0}',Status={1},Modify='{2}',ModifyDate='{3}' where TypeId={4}", typeInfo.TypeName, typeInfo.Status, typeInfo.Modify, typeInfo.ModifyDate, typeInfo.TypeId);
            return new MySqlHelper().ExcuteNonQuery(sql) > 0;
        }

        public TypeInfo QueryTypeInfo(int id)
        {
            return new MySqlHelper().FindOne<TypeInfo>("select * from WaterService.typeInfo where TypeId=" + id);
        }
    }
}
