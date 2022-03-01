using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Manager
{
    public class UserRoleManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile UserRoleManager _instance;
        public static UserRoleManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserRoleManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public UltimateResult<List<UserRole>> GetUserRoleCompany(UserRole parameter)
        {
            List<UserRole> users = new List<UserRole>();
            UltimateResult<List<UserRole>> result = new UltimateResult<List<UserRole>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[userRole_GetUserRoleCompany]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@CompanyId", parameter.CompanyId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    UserRole user = new UserRole();
                                    user.MenuRefId = Convert.ToInt32(read["name"]);
                                    user.UserRefId = Convert.ToInt32(read["surname"]);

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



    }
}
