using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Manager
{
    public class UserManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile UserManager _instance;
        public static UserManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserManager();
                        }
                    }
                }
                return _instance;
            }

        }


        public UltimateResult<List<User>> CheckUser(User user)
        {
            List<User> users = new List<User>();
            UltimateResult<List<User>> result = new UltimateResult<List<User>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[users_CheckUser]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@Company", user.Company);
                        sqlCommand.Parameters.AddWithValue("@UserName", user.UserName);
                        sqlCommand.Parameters.AddWithValue("@Password", user.Password);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    User usr = new User();
                                    usr.Id = Convert.ToInt32(read["Id"]);
                                    usr.Name = read["name"].ToString();
                                    usr.Surname = read["surname"].ToString();
                                    usr.CompanyId = Convert.ToInt32(read["companyId"]);

                                    users.Add(usr);
                                }
                            }
                            read.Close();
                        }

                        Log log = new Log();
                        log.Time = DateTime.Now;

                        if (users.Count > 0)
                        {
                            log.UserNo = user.UserId;
                            log.Type = LogType.LoginSucess;
                            LogManager.Instance.AddLog(log);

                            result.IsSuccess = true;
                            result.Message = "Başarıyla giriş yapıldı.";
                        }
                        else
                        {
                            log.Type = LogType.LoginFailed;
                            log.IncorrectPassword = user.Password;
                            log.IncorrectUserName = user.UserName;
                            log.IncorrectCompany = user.Company;
                            LogManager.Instance.AddLog(log);

                            result.IsSuccess = false;
                            result.Message = "Kullanıcı adı veya şifre yanlış.";
                        }

                        result.Data = users;
                        sqlCommand.Dispose();
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                result.IsSuccess = false;
                return result;
            }

            return result;
        }

        public UltimateResult<User> GetUser(User parameter)
        {
            User user = new User();
            UltimateResult<User> result = new UltimateResult<User>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[user_GetUser]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.UserId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    user.Name = read["name"].ToString();
                                    user.Surname = read["surname"].ToString();
                                    user.UserName = read["username"].ToString();
                                    user.MailAdress = read["mailAdress"].ToString();
                                    user.Telephone = read["telNo"].ToString();
                                    user.Company = read["company"].ToString();
                                    user.Title = read["title"].ToString();
                                    user.Department = read["department"].ToString();
                                    user.Linkedin = read["linkedin"].ToString();
                                    user.Facebook = read["facebook"].ToString();
                                    user.Twitter = read["twitter"].ToString();
                                    user.About = read["about"].ToString();
                                    user.Id = Convert.ToInt32(read["id"]);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = user;
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                result.IsSuccess = false;
                return result;
            }

            return result;
        }

        public UltimateResult<List<User>> GetUserCompany(User parameter)
        {
            List<User> users = new List<User>();
            UltimateResult<List<User>> result = new UltimateResult<List<User>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[user_GetUserCompany]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.CompanyId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    User user = new User();
                                    user.Name = read["name"].ToString();
                                    user.Surname = read["surname"].ToString();
                                    user.UserName = read["username"].ToString();
                                    user.MailAdress = read["mailAdress"].ToString();
                                    user.Telephone = read["telNo"].ToString();
                                    user.Company = read["company"].ToString();
                                    user.Title = read["title"].ToString();
                                    user.Department = read["department"].ToString();
                                    user.Linkedin = read["linkedin"].ToString();
                                    user.Facebook = read["facebook"].ToString();
                                    user.Twitter = read["twitter"].ToString();
                                    user.About = read["about"].ToString();
                                    user.Id = Convert.ToInt32(read["id"]);
                                    user.Gender = Convert.ToInt32(read["gender"]);

                                    users.Add(user);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = users;
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                result.IsSuccess = false;
                return result;
            }

            return result;
        }

        public UltimateResult<List<User>> GetUsers(User parameter)
        {
            List<User> users = new List<User>();
            UltimateResult<List<User>> result = new UltimateResult<List<User>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[user_GetUsers]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@companyId", parameter.CompanyId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    User user = new User();
                                    user.Name = read["name"].ToString();
                                    user.Surname = read["surname"].ToString();
                                    user.UserName = read["username"].ToString();
                                    user.MailAdress = read["mailAdress"].ToString();
                                    user.Telephone = read["telNo"].ToString();
                                    user.Company = read["company"].ToString();
                                    user.Title = read["title"].ToString();
                                    user.Department = read["department"].ToString();
                                    user.Linkedin = read["linkedin"].ToString();
                                    user.Facebook = read["facebook"].ToString();
                                    user.Twitter = read["twitter"].ToString();
                                    user.About = read["about"].ToString();
                                    user.Id = Convert.ToInt32(read["id"]);

                                    users.Add(user);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = users;
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                result.IsSuccess = false;
                return result;
            }

            return result;
        }

        public UltimateResult<List<User>> ChangePassword(User parameter)
        {
            List<User> users = new List<User>();
            UltimateResult<List<User>> result = new UltimateResult<List<User>>();
            SqlConnection sqlConnection = null;
            string Proc = "[user_ChangePassword]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.UserId);
                        sqlCommand.Parameters.AddWithValue("@newPass", parameter.Password);
                        sqlCommand.Parameters.AddWithValue("@oldPass", parameter.OldPassword);

                        result.IsSuccess = false;
                        int effectedRow = sqlCommand.ExecuteNonQuery();
                        result.IsSuccess = effectedRow > 0;

                        sqlCommand.Dispose();
                        result.Data = users;
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                result.IsSuccess = false;
                return result;
            }

            AddLog(parameter.UserId, "Şifre Güncellendi");

            return result;
        }

        public UltimateResult<User> UpdateProfile(User parameter)
        {
            UltimateResult<User> result = new UltimateResult<User>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[users_UpdateProfile]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.UserId);
                        sqlCommand.Parameters.AddWithValue("@linkedin", parameter.Linkedin);
                        sqlCommand.Parameters.AddWithValue("@facebook", parameter.Facebook);
                        sqlCommand.Parameters.AddWithValue("@twitter", parameter.Twitter);
                        sqlCommand.Parameters.AddWithValue("@about", parameter.About);

                        sqlCommand.ExecuteReader();
                        sqlCommand.Dispose();
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                result.IsSuccess = false;
                return result;
            }

            return result;
        }

        public UltimateResult<User> AddUser(User parameter)
        {
            UltimateResult<User> result = new UltimateResult<User>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[user_AddUser]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@name", parameter.Name);
                        sqlCommand.Parameters.AddWithValue("@surname", parameter.Surname);
                        sqlCommand.Parameters.AddWithValue("@username", parameter.UserName);
                        sqlCommand.Parameters.AddWithValue("@password", parameter.Password);
                        sqlCommand.Parameters.AddWithValue("@companyId", parameter.CompanyId);

                        int effectedRow = sqlCommand.ExecuteNonQuery();
                        result.IsSuccess = effectedRow > 0;
                        sqlConnection.Close();
                        sqlCommand.Dispose();
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                result.IsSuccess = false;
                return result;
            }

            AddLog(parameter.UserId, $"{parameter.Name} {parameter.Surname} isimli ıser eklendi");

            return result;
        }

    }
}
