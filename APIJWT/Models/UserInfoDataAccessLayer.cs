using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace APIJWT.Models
{
    public class UserInfoDataAccessLayer
    {
        string constr = "Server=(localdb)\\mssqllocaldb;Database=TaskManagementContext-a8012a34-ddd0-4227-aa17-d05a89f3f65c;Trusted_Connection=True;MultipleActiveResultSets=true";
        public UserModel GetloginUser(UserModel login)
        {
            var userinfo = new UserModel();
            using (SqlConnection con=new SqlConnection(constr))
            {
                string sql =string.Format(@"Select a.*,b.RoleName from UserInfo a inner join UserRole b on a.RoleId=b.RoleId where LoginId='{0}' and userPass='{1}'",login.LoginId,login.Password);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while(rd.Read())
                {
                    userinfo.UserId = Convert.ToInt32(rd["UserId"]);
                    userinfo.UserName = rd["UserName"].ToString();
                    userinfo.LoginId = rd["LoginId"].ToString();
                    userinfo.Password = rd["UserPass"].ToString();
                    userinfo.EmailAddress = rd["Email"].ToString();
                    userinfo.RoleName = rd["RoleName"].ToString();
                }
                return userinfo;
            }
        }
        public UserTask GetAllAssignedTask()
        {
            var userinfo = new UserTask();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format(@"select * from UserTask where IsDeleted=0");
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    
                        userinfo.AssignFrom = Convert.ToInt32(rd["AssignFrom"]);
                        userinfo.AssignTo = Convert.ToInt32(rd["AssignTo"]);
                    userinfo.Task = rd["TaskName"].ToString();
                    userinfo.AssignDate = Convert.ToDateTime(rd["AssignDate"]);
                    userinfo.ComplationDate = Convert.ToDateTime(rd["ComplationDate"].ToString());
                    userinfo.IsDeleted = Convert.ToBoolean(rd["IsDeleted"]);
                    userinfo.IsActive = Convert.ToBoolean(rd["IsActive"].ToString());
                    userinfo.Id = Convert.ToInt32(rd["TaskId"].ToString());
                }
                return userinfo;
            }
        }
        public UserTask AddTask(UserTask task)
        {
          
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format(@"Insert into UserTask (TaskName,AssignDate,ComplationDate,IsDeleted,IsActive,AssignFrom,AssignTo) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", task.Task,task.AssignDate,task.ComplationDate,task.IsActive,task.AssignFrom,task.AssignTo);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                
              
                return task;
            }
        }
        public UserModel AddUser(UserModel user)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format(@"Insert into UserInfo (LoginId,UserName,UserPass,Email,RoleId,IsActive) values('{0}','{1}','{2}','{3}','{4}','{5}')", user.LoginId, user.UserName, user.Password, user.EmailAddress, user.UserRole.RoleId, user.IsActive);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();


                return user;
            }
        }
        public UserModel DeleteUser(UserModel user)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format(@"Update UserInfo set IsActive=0");
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();


                return user;
            }
        }
        public UserTask GetEmployesTask(UserModel user)
        {
            var userinfo = new UserTask();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format(@"select * from UserTask where IsDeleted=0 and AssignTo='{0}'",user.UserId);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {

                    userinfo.AssignFrom = Convert.ToInt32(rd["AssignFrom"]);
                    userinfo.AssignTo = Convert.ToInt32(rd["AssignTo"]);
                    userinfo.Task = rd["TaskName"].ToString();
                    userinfo.AssignDate = Convert.ToDateTime(rd["AssignDate"]);
                    userinfo.ComplationDate = Convert.ToDateTime(rd["ComplationDate"].ToString());
                    userinfo.IsDeleted = Convert.ToBoolean(rd["IsDeleted"]);
                    userinfo.IsActive = Convert.ToBoolean(rd["IsActive"].ToString());
                    userinfo.Id = Convert.ToInt32(rd["TaskId"].ToString());
                }
                return userinfo;
            }
        }
    }
}
