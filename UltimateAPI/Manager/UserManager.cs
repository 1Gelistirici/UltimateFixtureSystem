using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using UltimateAPI.CallManager;
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


        public UltimateResult<User> CheckUser(User user)
        {
            User userData = new User();
            UltimateResult<User> result = new UltimateResult<User>();
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
                        sqlCommand.Parameters.AddWithValue("@Password", Functions.Hashing.SHA_512_Encrypting(user.Password));

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    User usr = new User();
                                    usr.Id = Convert.ToInt32(read["Id"]);
                                    usr.Name = read["name"].ToString();
                                    usr.UserName = read["username"].ToString();
                                    usr.Surname = read["surname"].ToString();
                                    usr.ImageName = read["ImageName"].ToString();
                                    usr.ImageUrl = read["imageUrl"].ToString();
                                    usr.Company = read["company"].ToString();
                                    usr.CompanyId = Convert.ToInt32(read["companyId"]);
                                    usr.Lock = Convert.ToBoolean(read["lock"]);

                                    userData = usr;
                                }
                            }
                            read.Close();
                        }

                        Log log = new Log();
                        log.Time = DateTime.Now;

                        if (userData != null && userData.Id > 0)
                        {
                            log.UserNo = user.UserId;

                            if (userData.Lock)
                            {
                                log.Type = LogType.LoginFailed;
                                LogManager.Instance.AddLog(log);

                                result.Message = "Hesap kilitlidir.";
                                result.IsSuccess = false;
                                return result;
                                //return nereye dönüyort - sql bağlantısını kapat
                            }

                            log.Type = LogType.LoginSucess;
                            log.Detail = "Giriş yapıldı.";
                            log.UserNo = userData.Id;
                            log.IpAddress = user.IpAddress;
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
                            log.IpAddress = user.IpAddress;
                            log.UserNo = userData.Id;
                            log.Detail = "Başarısız giriş denemesi.";
                            LogManager.Instance.AddLog(log);

                            result.IsSuccess = false;
                            result.Message = "Kullanıcı adı veya şifre yanlış.";
                        }

                        result.Data = userData;
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
                                    user.Id = Convert.ToInt32(read["id"]);
                                    user.Name = read["name"].ToString();
                                    user.Surname = read["surname"].ToString();
                                    user.UserName = read["username"].ToString();
                                    user.MailAdress = read["mailAdress"].ToString();
                                    user.Telephone = read["telNo"].ToString();
                                    user.Company = read["company"].ToString();
                                    user.Title = read["title"].ToString();
                                    user.Department = Convert.ToInt32(read["departmentId"]);
                                    user.Linkedin = read["linkedin"].ToString();
                                    user.Facebook = read["facebook"].ToString();
                                    user.Twitter = read["twitter"].ToString();
                                    user.About = read["about"].ToString();
                                    user.Lock = Convert.ToBoolean(read["lock"]);
                                    user.ImageUrl = Convert.ToString(read["ImageUrl"]);
                                    //user.Role = UserRoleCallManager.Instance.GetRole(new UserRole { UserRefId = user.Id }).Data;
                                    user.ImageName = read["ImageName"].ToString();

                                    result.IsSuccess = true;
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();

                        if (result.IsSuccess)
                        {
                            List<UserRole> userRoles = UserRoleCallManager.Instance.GetRoleCompanyUsers(new ReferansParameter() { RefId = parameter.CompanyId }).Data;
                            user.Role = userRoles.Where(x => x.UserRefId == user.Id).ToList();
                        }

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

        public UltimateResult<User> GetUserCompanyUserName(User parameter)
        {
            User user = new User();
            UltimateResult<User> result = new UltimateResult<User>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[user_GetUserCompanyUsername]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@Company", parameter.Company);
                        sqlCommand.Parameters.AddWithValue("@UserName", parameter.UserName);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    user.Id = Convert.ToInt32(read["id"]);
                                    user.Name = read["name"].ToString();
                                    user.Surname = read["surname"].ToString();
                                    user.UserName = read["username"].ToString();
                                    user.MailAdress = read["mailAdress"].ToString();
                                    user.ImageName = read["ImageName"].ToString();

                                    result.IsSuccess = true;
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
                                    user.Department = Convert.ToInt32(read["departmentId"]);
                                    user.Linkedin = read["linkedin"].ToString();
                                    user.Facebook = read["facebook"].ToString();
                                    user.Twitter = read["twitter"].ToString();
                                    user.About = read["about"].ToString();
                                    user.Id = Convert.ToInt32(read["id"]);
                                    user.Gender = Convert.ToBoolean(read["gender"]);
                                    user.Lock = Convert.ToBoolean(read["lock"]);
                                    user.ImageUrl = Convert.ToString(read["ImageUrl"]);
                                    //user.Role = UserRoleCallManager.Instance.GetRole(new UserRole { UserRefId = user.Id }).Data;
                                    user.ImageName = read["ImageName"].ToString();

                                    users.Add(user);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);

                    if (result.IsSuccess && result.Data != null)
                    {
                        List<UserRole> userRoles = UserRoleCallManager.Instance.GetRoleCompanyUsers(new ReferansParameter() { RefId = parameter.CompanyId }).Data;
                        foreach (User user in result.Data)
                        {
                            user.Role = userRoles.Where(x => x.UserRefId == user.Id).ToList();
                        }
                    }

                    result.Data = users;
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
                                    user.Department = Convert.ToInt32(read["departmentId"]);
                                    user.Linkedin = read["linkedin"].ToString();
                                    user.Facebook = read["facebook"].ToString();
                                    user.Twitter = read["twitter"].ToString();
                                    user.About = read["about"].ToString();
                                    user.Id = Convert.ToInt32(read["id"]);
                                    user.Lock = Convert.ToBoolean(read["lock"]);
                                    user.ImageUrl = Convert.ToString(read["ImageUrl"]);
                                    user.ImageName = read["ImageName"].ToString();

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

        public UltimateResult<List<User>> GetAllUser()
        {
            List<User> users = new List<User>();
            UltimateResult<List<User>> result = new UltimateResult<List<User>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[user_GetAllUser]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

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
                                    user.Department = Convert.ToInt32(read["departmentId"]);
                                    user.Linkedin = read["linkedin"].ToString();
                                    user.Facebook = read["facebook"].ToString();
                                    user.Twitter = read["twitter"].ToString();
                                    user.About = read["about"].ToString();
                                    user.Id = Convert.ToInt32(read["id"]);
                                    user.Lock = Convert.ToBoolean(read["lock"]);
                                    user.ImageUrl = Convert.ToString(read["ImageUrl"]);
                                    user.ImageName = read["ImageName"].ToString();

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
                        sqlCommand.Parameters.AddWithValue("@newPass", Functions.Hashing.SHA_512_Encrypting(parameter.Password));
                        sqlCommand.Parameters.AddWithValue("@oldPass", Functions.Hashing.SHA_512_Encrypting(parameter.OldPassword));

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

        public bool ForgetChangePassword(User parameter)
        {
            List<User> users = new List<User>();
            bool result = false;
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[users_ForgetChangePassword]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@Id", parameter.UserId);
                        sqlCommand.Parameters.AddWithValue("@Password", Functions.Hashing.SHA_512_Encrypting(parameter.Password));

                        int effectedRow = sqlCommand.ExecuteNonQuery();
                        result = effectedRow > 0;

                        sqlCommand.Dispose();
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
                result = false;
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

        public UltimateResult<User> UpdateUser(User parameter)
        {
            UltimateResult<User> result = new UltimateResult<User>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[users_UpdateUser]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.UserId);
                        sqlCommand.Parameters.AddWithValue("@name", parameter.Name);
                        sqlCommand.Parameters.AddWithValue("@surname", parameter.Surname);
                        sqlCommand.Parameters.AddWithValue("@username", parameter.UserName);
                        sqlCommand.Parameters.AddWithValue("@mailAdress", parameter.MailAdress);
                        sqlCommand.Parameters.AddWithValue("@telNo", parameter.Telephone);
                        sqlCommand.Parameters.AddWithValue("@title", parameter.Title);
                        sqlCommand.Parameters.AddWithValue("@departmentId", parameter.Department);
                        sqlCommand.Parameters.AddWithValue("@gender", parameter.Gender);
                        sqlCommand.Parameters.AddWithValue("@lock", parameter.Lock);
                        sqlCommand.Parameters.AddWithValue("@ImageName", parameter.ImageName);
                        sqlCommand.Parameters.AddWithValue("@ImageUrl", parameter.ImageUrl);

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

            return result;
        }

        public UltimateSetResult AddUser(User parameter)
        {
            UltimateSetResult result = new UltimateSetResult();
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
                        sqlCommand.Parameters.AddWithValue("@password", Functions.Hashing.SHA_512_Encrypting(parameter.Password));
                        sqlCommand.Parameters.AddWithValue("@gender", parameter.Gender);
                        sqlCommand.Parameters.AddWithValue("@companyId", parameter.CompanyId);
                        sqlCommand.Parameters.AddWithValue("@title", parameter.Title);
                        sqlCommand.Parameters.AddWithValue("@departmentId", parameter.Department);
                        sqlCommand.Parameters.AddWithValue("@lock", parameter.Lock);
                        sqlCommand.Parameters.AddWithValue("@ImageName", parameter.ImageName);
                        sqlCommand.Parameters.AddWithValue("@ImageUrl", parameter.ImageUrl);
                        sqlCommand.Parameters.AddWithValue("@ResultId", SqlDbType.Int).Direction = ParameterDirection.Output;

                        int effectedRow = sqlCommand.ExecuteNonQuery();
                        result.IsSuccess = effectedRow > 0;
                        result.ReturnId = (int)sqlCommand.Parameters["@ResultId"].Value;


                        if (effectedRow == -1)
                        {
                            result.Message = "Kullanıcı adını değiştiriniz.";
                        }

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

            AddLog(parameter.UserId, $"{parameter.Name} {parameter.Surname} isimli user eklendi");

            return result;
        }

        public bool DeleteUser(User parameter)
        {
            bool result = false;
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[users_DeleteUser]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);

                        int effectedRow = sqlCommand.ExecuteNonQuery();
                        result = effectedRow > 0;
                        sqlConnection.Close();
                        sqlCommand.Dispose();
                    }
                    ConnectionManager.Instance.Dispose(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.Excep(ex, sqlConnection);
            }

            AddLog(parameter.UserId, "Demirbaş Silindi");

            return result;
        }

    }
}
