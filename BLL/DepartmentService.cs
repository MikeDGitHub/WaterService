using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using DAL.Manage;
using Model.Oauth;

namespace BLL
{
    public class DepartmentService
    {
        private readonly DepartmentManager dal = new DepartmentManager();
        public bool Add(DepartmentInfo dep)
        {
            return dal.Add(dep);
        }

        public bool Update(DepartmentInfo dep)
        {
            return dal.Update(dep);
        }

        public List<DepartmentInfo> GetList(int parentId = 0)
        {
            return dal.GetList(parentId);
        }

        public bool CheckDepName(string depName)
        {
            return dal.CheckDepName(depName);
        }

        public DepartmentInfo GetModelById(int id)
        {
            return dal.GetModelById(id);
        }
    }
}
