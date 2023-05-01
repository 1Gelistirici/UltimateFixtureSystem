using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

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


        public UltimateResult<List<UserRole>> GetRole(UserRole parameter)
        {
            List<UserRole> roles = new List<UserRole>();
            UltimateResult<List<UserRole>> result = new UltimateResult<List<UserRole>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[userRole_GetRole]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@CompanyRefId", parameter.CompanyRefId);
                        sqlCommand.Parameters.AddWithValue("@UserRefId", parameter.UserRefId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    UserRole userRole = new UserRole();
                                    userRole.Id = Convert.ToInt32(read["Id"]);
                                    userRole.MenuRefId = Convert.ToInt32(read["MenuRefId"]);
                                    userRole.UserRefId = Convert.ToInt32(read["UserRefId"]);

                                    roles.Add(userRole);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = roles;
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

        public UltimateResult<List<UserRole>> AddRole(UserRole parameter)
        {
            UltimateResult<List<UserRole>> result = new UltimateResult<List<UserRole>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[userRole_AddUserRole]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@MenuRefId", parameter.MenuRefId);
                        sqlCommand.Parameters.AddWithValue("@UserRefId", parameter.UserRefId);
                        sqlCommand.Parameters.AddWithValue("@CompanyRefId", parameter.CompanyRefId);

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
                result.Message = ex.Message;
                return result;
            }

            return result;
        }

        public UltimateResult<List<UserRole>> DeleteRole(UserRole parameter)
        {
            UltimateResult<List<UserRole>> result = new UltimateResult<List<UserRole>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[userRole_DeleteUserRole]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@UserRefId", parameter.UserRefId);
                        sqlCommand.Parameters.AddWithValue("@CompanyRefId", parameter.CompanyRefId);
                        sqlCommand.Parameters.AddWithValue("@MenuRefId", parameter.MenuRefId);

                        //int effectedRow = sqlCommand.ExecuteNonQuery();
                        //result.IsSuccess = effectedRow > 0;
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
                result.Message = ex.Message;
                return result;
            }

            return result;
        }
    }
}
