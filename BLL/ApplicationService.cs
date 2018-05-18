using System;
using System.Collections.Generic;
using System.Text;
using Model.Oauth;

namespace BLL
{
    public class ApplicationService
    {
        public List<ApplicationInfo> GetList()
        {
            return new DAL.Manage.ApplicationManage().GetList();
        }
    }
}
