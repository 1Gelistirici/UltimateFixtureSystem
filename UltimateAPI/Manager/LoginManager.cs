using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Manager
{
    public class LoginManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile LoginManager _instance;
        public static LoginManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LoginManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<User>> Authenticate(User user)
        {
            List<User> users = new List<User>();
            UltimateResult<List<User>> result = new UltimateResult<List<User>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[CheckUser]";

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

                                    users.Add(usr);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = users;

                        if (result.IsSuccess)
                        {
                            Log log = new Log();
                            log.Detail = "Giriş yapıldı.";
                            log.UserNo = users[0].UserId;
                            log.Type = LogType.LoginSucess;
                            log.IpAddress = user.IpAddress;
                            LogManager.Instance.AddLog(log);
                        }
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

    }
}
