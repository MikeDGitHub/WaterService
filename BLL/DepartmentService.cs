using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Model.Oauth;

namespace BLL
{
    public class DepartmentService
    {
        public bool Add(DepartmentInfo dep)
        {
            return new DAL.Manage.DepartmentManager().Add(dep);
        }

        public bool Update(DepartmentInfo dep)
        {
            return new DAL.Manage.DepartmentManager().Update(dep);
        }

        public List<DepartmentInfo> GetList(int parentId = 0)
        {
            return new DAL.Manage.DepartmentManager().GetList(parentId);
        }

        public bool CheckDepName(string depName)
        {
            return new DAL.Manage.DepartmentManager().CheckDepName(depName);
        }

        public DepartmentInfo GetModelById(int id)
        {
            return new DAL.Manage.DepartmentManager().GetModelById(id);
        }
    }
}
