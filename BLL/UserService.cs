using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Oauth;
using Model.ViewModel;

namespace BLL
{
    public class UserService
    {
        public bool AddUser(RegisterModel register)
        {
            return new DAL.Manage.UserManage().AddUser(register);
        }

        public Task<int> Login(string userName, string password)
        {
            return new DAL.Manage.UserManage().Login(userName, password);
        }

        public Task<Userinfo> GetUserInfo(int userId, int appId)
        {
            return new DAL.Manage.UserManage().GetUserInfo(userId, appId);
        }

        public bool CheckLoginName(string loginName)
        {
            return new DAL.Manage.UserManage().CheckLoginName(loginName);
        }

        public bool CheckPhoneNumber(string phoneNumber)
        {
            return new DAL.Manage.UserManage().CheckPhoneNumber(phoneNumber);
        }

        public string UpdatePassWord(string newPwd, string oldPwd, int userId)
        {
            return new DAL.Manage.UserManage().UpdatePassWord(newPwd, oldPwd, userId);
        }

        public bool UpdateLogoImageUrl(string logoImageUrl, int userId)
        {
            return new DAL.Manage.UserManage().UpdateLogoImageUrl(logoImageUrl, userId);
        }

        public bool UpdatePhoneNumber(string phoneNumber, int userId)
        {
            return new DAL.Manage.UserManage().UpdatePhoneNumber(phoneNumber, userId);
        }

        public bool UpdateDepartment(int depId, int userId)
        {
            return new DAL.Manage.UserManage().UpdateDepartment(depId, userId);
        }

        public UserInfoViewModel QueryUserList(QueryModel query)
        {
            var where = new StringBuilder();
            where.Append(" where 1=1 ");
            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Name))
                {
                    where.AppendFormat(" and  UserName like '%{0}%'", query.Name);
                }
            }
            else
            {
                query = new QueryModel();
            }
            var v = new DAL.Manage.UserManage().QueryUserList(where.ToString());
            v.List = v.List.Skip(query.PageIndex * query.PageSize).Take(query.PageSize).ToList();
            return v;
        }

        public Model.Oauth.Userinfo QueryUserInfo(int userId)
        {
            return new DAL.Manage.UserManage().QueryUserInfo(userId);
        }
    }
}
