using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;
using Model.Oauth;

namespace DAL.Manage
{
    public class ApplicationManage
    {
        public List<ApplicationInfo> GetList()
        {
            return new MySqlHelper().FindToList<ApplicationInfo>("select ApplicationId ,DisplayName ,`Create`,CreateDate,Modify,ModifyDate from oauth.applicationInfo").ToList();
        }
    }
}
