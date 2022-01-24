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
                                    usr.Company = read["company"].ToString();

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
                        }
                        else
                        {
                            log.Type = LogType.LoginFailed;
                            log.IncorrectPassword = user.Password;
                            log.IncorrectUserName = user.UserName;
                            log.IncorrectCompany = user.Company;

                            LogManager.Instance.AddLog(log);
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

        public UltimateResult<List<User>> GetUser(User parameter)
        {
            List<User> users = new List<User>();
            UltimateResult<List<User>> result = new UltimateResult<List<User>>();
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

        //public UltimateResult<List<User>> GetAccessories()
        //{
        //    List<User> accessories = new List<User>();
        //    UltimateResult<List<User>> result = new UltimateResult<List<User>>();
        //    SqlConnection sqlConnection = null;
        //    string Proc = "[dbo].[accessories_GetAccessories]";

        //    try
        //    {
        //        using (sqlConnection =  Global.GetSqlConnection())
        //        {
        //            ConnectionManager.Instance.SqlConnect(sqlConnection);

        //            using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
        //            {
        //                ConnectionManager.Instance.CmdOperations();

        //                using (SqlDataReader read = sqlCommand.ExecuteReader())
        //                {
        //                    if (read.HasRows)
        //                    {
        //                        while (read.Read())
        //                        {
        //                            User accessory = new User();
        //                            accessory.Id = Convert.ToInt32(read["id"]);
        //                            accessory.Name = read["name"].ToString();
        //                            accessory.Piece = Convert.ToInt32(read["piece"]);
        //                            accessory.ModelNo = Convert.ToInt32(read["model_no"]);
        //                            accessory.UserNo = Convert.ToInt32(read["user_no"]);
        //                            accessory.BillNo = Convert.ToInt32(read["bill_no"]);
        //                            accessory.StatuNo = Convert.ToInt32(read["statu_no"]);
        //                            accessory.CategoryNo = Convert.ToInt32(read["category_no"]);

        //                            accessories.Add(accessory);
        //                        }
        //                    }
        //                    read.Close();
        //                }
        //                sqlCommand.Dispose();
        //                result.Data = accessories;
        //            }
        //            ConnectionManager.Instance.Dispose(sqlConnection);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ConnectionManager.Instance.Excep(ex, sqlConnection);
        //        result.IsSuccess = false;
        //    }

        //    return result;
        //}

        //public UltimateResult<List<User>> AddAccessory(User parameter)
        //{
        //    UltimateResult<List<User>> result = new UltimateResult<List<User>>();
        //    SqlConnection sqlConnection = null;
        //    string Proc = "[dbo].[accessories_AddAccessory]";

        //    try
        //    {
        //        using (sqlConnection =  Global.GetSqlConnection())
        //        {
        //            ConnectionManager.Instance.SqlConnect(sqlConnection);

        //            using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
        //            {
        //                ConnectionManager.Instance.CmdOperations();

        //                sqlCommand.Parameters.AddWithValue("@name", parameter.Name);
        //                sqlCommand.Parameters.AddWithValue("@piece", parameter.Piece);
        //                sqlCommand.Parameters.AddWithValue("@model_no", parameter.ModelNo);
        //                sqlCommand.Parameters.AddWithValue("@user_no", parameter.UserNo);
        //                sqlCommand.Parameters.AddWithValue("@bill_no", parameter.BillNo);
        //                sqlCommand.Parameters.AddWithValue("@statu_no", parameter.StatuNo);
        //                sqlCommand.Parameters.AddWithValue("@category_no", parameter.CategoryNo);

        //                int effectedRow = sqlCommand.ExecuteNonQuery();
        //                result.IsSuccess = effectedRow > 0;
        //                sqlConnection.Close();
        //                sqlCommand.Dispose();

        //            }
        //            ConnectionManager.Instance.Dispose(sqlConnection);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ConnectionManager.Instance.Excep(ex, sqlConnection);
        //    }

        //    return result;
        //}

        //public UltimateResult<List<User>> DeleteAccessory(User parameter)
        //{
        //    UltimateResult<List<User>> result = new UltimateResult<List<User>>();
        //    SqlConnection sqlConnection = null;
        //    string Proc = "[dbo].[accessories_DeleteAccessory]";

        //    try
        //    {
        //        using (sqlConnection = new SqlConnection(@"Data Source=SKY-NET\SQLEXPRESS;Initial Catalog=UDemirbas;Integrated Security=True"))
        //        {
        //            ConnectionManager.Instance.SqlConnect(sqlConnection);

        //            using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
        //            {
        //                ConnectionManager.Instance.CmdOperations();

        //                sqlCommand.Parameters.AddWithValue("@id", parameter.Id);

        //                int effectedRow = sqlCommand.ExecuteNonQuery();
        //                result.IsSuccess = effectedRow > 0;
        //                sqlConnection.Close();
        //                sqlCommand.Dispose();

        //            }
        //            ConnectionManager.Instance.Dispose(sqlConnection);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ConnectionManager.Instance.Excep(ex, sqlConnection);
        //    }

        //    return result;
        //}

        //public UltimateResult<List<User>> UpdateAccessory(User parameter)
        //{
        //    UltimateResult<List<User>> result = new UltimateResult<List<User>>();
        //    SqlConnection sqlConnection = null;
        //    string Proc = "[dbo].[accessories_UpdateAccessory]";

        //    try
        //    {
        //        using (sqlConnection = new SqlConnection(@"Data Source=SKY-NET\SQLEXPRESS;Initial Catalog=UDemirbas;Integrated Security=True"))
        //        {
        //            ConnectionManager.Instance.SqlConnect(sqlConnection);

        //            using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
        //            {
        //                ConnectionManager.Instance.CmdOperations();

        //                sqlCommand.Parameters.AddWithValue("@id", parameter.Id);
        //                sqlCommand.Parameters.AddWithValue("@name", parameter.Name);
        //                sqlCommand.Parameters.AddWithValue("@piece", parameter.Piece);
        //                sqlCommand.Parameters.AddWithValue("@model_no", parameter.ModelNo);
        //                sqlCommand.Parameters.AddWithValue("@user_no", parameter.UserNo);
        //                sqlCommand.Parameters.AddWithValue("@bill_no", parameter.BillNo);
        //                sqlCommand.Parameters.AddWithValue("@statu_no", parameter.StatuNo);
        //                sqlCommand.Parameters.AddWithValue("@category_no", parameter.CategoryNo);

        //                int effectedRow = sqlCommand.ExecuteNonQuery();
        //                result.IsSuccess = effectedRow > 0;
        //                sqlConnection.Close();
        //                sqlCommand.Dispose();
        //            }
        //            ConnectionManager.Instance.Dispose(sqlConnection);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ConnectionManager.Instance.Excep(ex, sqlConnection);
        //    }

        //    return result;
        //}



    }
}
