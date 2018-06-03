using DAL.Helper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Oauth;
using Model.ViewModel;
using Model.WaterService;
using YuanXin.Framework;

namespace DAL.Manage
{
    public class UserManage
    {
        private string sql = @"SELECT  u.UserID,u.UserName,u.LoginName,u.PhoneNumber,u.UserEmail,u.LogoImageUrl,u.depID FROM 
OAuth.UserInfo AS u LEFT JOIN ACL.ApplicationAndUser a on a.UserID=u.UserID  where  a.ApplicationId=@appId  and u.userId=@userId order by u.userId desc limit 1; ";
        public bool AddUser(RegisterModel register)
        {
            sql = "insert into oauth.userinfo (UserName,LoginName,PhoneNumber,LogoImageUrl,UserEmail,Status,DepId) values(@UserName,@LoginName,@PhoneNumber,@LogoImageUrl,@UserEmail,@Status,@DepId);select @@IDENTITY;";
            var param = new DynamicParameters();
            param.Add("@UserName", register.UserName, DbType.String);
            param.Add("@LoginName", register.LoginName, DbType.String);
            param.Add("@PhoneNumber", register.Mobile, DbType.String);
            param.Add("@LogoImageUrl", register.LogoImageUrl, DbType.String);
            param.Add("@UserEmail", register.UserEmail, DbType.String);
            param.Add("@Status", register.Status ? 1 : 0, DbType.Int32);
            param.Add("@DepId", register.DepId, DbType.Int32);
            var userId = new MySqlHelper().ExecuteScalar(sql, param);
            if (userId != null)
            {
                sql =
                    "insert into oauth.UserPassword (UserId,Password,LoginName)values(@UserID,@Password,@LoginName);insert into acl.applicationanduser(ApplicationId,UserID) values (@ApplicationId,@UserID)";
                param = new DynamicParameters();
                param.Add("@ApplicationId", register.ClientId, DbType.Int32);
                param.Add("@UserID", int.Parse(userId.ToString()), DbType.Int32);
                param.Add("@Password", register.Password.GetMD5(), DbType.String);
                param.Add("@LoginName", register.LoginName, DbType.String);
                return new MySqlHelper().ExcuteNonQuery(sql, param) > 0;
            }
            else
            {
                return false;
            }
        }
        public Task<int> Login(string userName, string password)
        {
            string sqlString = "";
            var param = new DynamicParameters();
            if (userName.IsMobileNumber())
            {
                sqlString = "select up.UserID from OAuth.UserPassword up left join oauth.UserInfo u on up.UserId=u.UserId where u.PhoneNumber=@PhoneNumber and Password=@Password and Status=1 ";
                param.Add("@PhoneNumber", userName, DbType.String);
            }
            else if (userName.IsEmail())
            {
                sqlString = "select up.UserID from OAuth.UserPassword up left join oauth.UserInfo u on up.UserId=u.UserId where u.UserEmail=@UserEmail and Password=@Password  and Status=1 ";
                param.Add("@UserEmail", userName, DbType.String);
            }
            else
            {
                sqlString = "select UserID from OAuth.UserPassword where LoginName=@UserName and Password=@Password";
                param.Add("@UserName", userName, DbType.String);
            }
            int userId = 0;
            param.Add("@Password", password.GetMD5(), DbType.String);
            object obj = new MySqlHelper().ExecuteScalar(sqlString, param);
            if (obj != null)
            {
                userId = Convert.ToInt32(obj.ToString());
            }
            return Task.FromResult(userId);
        }

        public Task<Userinfo> GetUserInfo(int userId, int appId)
        {
            var param = new DynamicParameters();
            param.Add("@userId", userId, DbType.Int32);
            param.Add("@appId", appId, DbType.Int32);
            return Task.FromResult(new MySqlHelper().FindOne<Userinfo>(sql, param));
        }

        public bool CheckLoginName(string loginName)
        {
            sql = string.Format("select * from OAuth.UserInfo where LoginName='{0}'", loginName);
            var b = new MySqlHelper().FindToList<UserInfo>(sql);
            return b.Any();
        }

        public bool CheckPhoneNumber(string phoneNumber)
        {
            sql = string.Format("select * from OAuth.UserInfo where PhoneNumber='{0}'", phoneNumber);
            var b = new MySqlHelper().FindToList<UserInfo>(sql);
            return b.Any();
        }

        public string UpdatePassWord(string newPwd, string oldPwd, int userId)
        {
            sql = "select * from oauth.UserPassword where UserID=@UserID and Password=@Password ;";
            var param = new DynamicParameters();
            param.Add("@UserID", userId, DbType.Int32);
            param.Add("@Password", oldPwd.GetMD5(), DbType.String);
            var b = new MySqlHelper().FindToList<UserPassword>(sql, param);
            if (b.Any())
            {
                sql = " update oauth.UserPassword set Password=@Password  where UserID=@UserID;";
                param = new DynamicParameters();
                param.Add("@UserID", userId, DbType.Int32);
                param.Add("@Password", newPwd.GetMD5(), DbType.String);
                var flag = new MySqlHelper().ExcuteNonQuery(sql, param);
                return flag > 0 ? "更新成功。" : "更新失败。";
            }
            else
            {
                return "原始密码错误。";
            }
        }

        public bool UpdateLogoImageUrl(string logoImageUrl, int userId)
        {
            sql = "update oauth.userinfo set LogoImageUrl=@logoImageUrl  where UserID=@UserID;";
            var param = new DynamicParameters();
            param.Add("@UserID", userId, DbType.Int32);
            param.Add("@logoImageUrl", logoImageUrl, DbType.String);

            return new MySqlHelper().ExcuteNonQuery(sql, param) > 0;
        }

        public bool UpdatePhoneNumber(string phoneNumber, int userId)
        {
            if (phoneNumber.IsMobileNumber())
            {
                sql = "update oauth.userinfo set phoneNumber=@phoneNumber  where UserID=@UserID;";
                var param = new DynamicParameters();
                param.Add("@UserID", userId, DbType.Int32);
                param.Add("@phoneNumber", phoneNumber, DbType.String);

                return new MySqlHelper().ExcuteNonQuery(sql, param) > 0;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateDepartment(int depId, int userId)
        {
            sql = "update oauth.userinfo set DepId=@DepId  where UserID=@UserID;";
            var param = new DynamicParameters();
            param.Add("@UserID", userId, DbType.Int32);
            param.Add("@DepId", depId, DbType.String);
            return new MySqlHelper().ExcuteNonQuery(sql, param) > 0;
        }

        public bool Add_WaterService_UserInfo(Model.WaterService.UserInfo user, object id)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("insert into WaterService.UserInfo(UserName,UserAddress,UserPhone,MeterId,Remark,`Create`,CreateDate) values('{0}','{1}','{2}',{6},'{3}','{4}','{5}');", user.UserName, user.UserAddress, user.UserPhone, user.Remark, user.Create, user.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), id);
            return new MySqlHelper().ExcuteNonQuery(sb.ToString()) > 0;
        }

        public bool UpDate_WaterService_UserInfo(Model.WaterService.UserInfo user)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("update WaterService.UserInfo set UserName='{0}',UserAddress='{1}',UserPhone='{2}',Remark ='{3}',Modify='{4}',ModifyDate='{5}' where UserId={6};", user.UserName, user.UserAddress, user.UserPhone, user.Remark, user.Modify, user.ModifyDate.ToString("yyyy-MM-dd HH:mm:ss"), user.UserId);
            return new MySqlHelper().ExcuteNonQuery(sb.ToString()) > 0;
        }

        public UserInfoViewModel QueryUserList(string where)
        {
            var valve = new UserInfoViewModel();
            sql = " select * from  oauth.userinfo " + where;
            valve.List = new MySqlHelper().FindToList<Userinfo>(sql).ToList();
            valve.TotalCount = valve.List.Count;
            return valve;
        }
        public Model.Oauth.Userinfo QueryUserInfo(int userId)
        {
            sql = " select * from  oauth.userinfo where UserId=" + userId;
            return new MySqlHelper().FindOne<Userinfo>(sql);
        }
        public bool UpdateUser(Model.Oauth.Userinfo user)
        {
            sql = $"update oauth.userinfo set LoginName='{user.LoginName}',PhoneNumber='{user.PhoneNumber}',Status={user.Status},LogoImageUrl='{user.LogoImageUrl}',DepId={user.DepId},UserEmail='{user.UserEmail}',UserName='{user.UserName}'  where UserId={user.UserId}";
            return new MySqlHelper().ExcuteNonQuery(sql) > 0;
        }
    }
}
