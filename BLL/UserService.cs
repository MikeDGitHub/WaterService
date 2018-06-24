using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Manage;
using Model.Oauth;
using Model.ViewModel;

namespace BLL
{
    public class UserService
    {
        private readonly UserManage dal = new UserManage();
        public bool AddUser(RegisterModel register)
        {
            return dal.AddUser(register);
        }

        public Task<int> Login(string userName, string password)
        {
            return dal.Login(userName, password);
        }

        public Task<Userinfo> GetUserInfo(int userId, int appId)
        {
            return dal.GetUserInfo(userId, appId);
        }

        public bool CheckLoginName(string loginName)
        {
            return dal.CheckLoginName(loginName);
        }

        public bool CheckPhoneNumber(string phoneNumber)
        {
            return dal.CheckPhoneNumber(phoneNumber);
        }

        public string UpdatePassWord(string newPwd, string oldPwd, int userId)
        {
            return dal.UpdatePassWord(newPwd, oldPwd, userId);
        }

        public bool UpdateLogoImageUrl(string logoImageUrl, int userId)
        {
            return dal.UpdateLogoImageUrl(logoImageUrl, userId);
        }

        public bool UpdatePhoneNumber(string phoneNumber, int userId)
        {
            return dal.UpdatePhoneNumber(phoneNumber, userId);
        }

        public bool UpdateDepartment(int depId, int userId)
        {
            return dal.UpdateDepartment(depId, userId);
        }

        public UserInfoViewModel QueryUserList(SearchModel query)
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
                query = new SearchModel();
            }
            var v = dal.QueryUserList(where.ToString());
            v.List = v.List.Skip(query.PageIndex * query.PageSize).Take(query.PageSize).ToList();
            var depList = new DepartmentManager().GetList();
            v.List.ForEach(item =>
            {
                var dep = depList.Find(p => p.DepId == item.DepId);
                if (dep != null)
                {
                    item.DepName = dep.DepName;
                }
            });
            return v;
        }

        public Model.Oauth.Userinfo QueryUserInfo(int userId)
        {
            return dal.QueryUserInfo(userId);
        }

        public bool UpdateUser(Model.Oauth.Userinfo user)
        {
            return dal.UpdateUser(user);
        }

        public string ResetPassword(Model.Oauth.Userinfo user)
        {
            return dal.ResetPassword(user);
        }
    }
}
