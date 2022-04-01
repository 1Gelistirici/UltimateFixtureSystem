using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class RelevantPersonnelManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile RelevantPersonnelManager _instance;
        public static RelevantPersonnelManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new RelevantPersonnelManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<RelevantPersonnel>> AddRelevantPersonnel(RelevantPersonnel parameter)
        {
            UltimateResult<List<RelevantPersonnel>> result = new UltimateResult<List<RelevantPersonnel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[relevantPersonnel_AddRelevantPersonnel]";

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

        public UltimateResult<List<RelevantPersonnel>> DeleteRelevantPersonnel(ReferansParameter parameter)
        {
            UltimateResult<List<RelevantPersonnel>> result = new UltimateResult<List<RelevantPersonnel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[relevantPersonnel_DeleteRelevantPersonnel]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@Id", parameter.Id);

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

        public UltimateResult<List<RelevantPersonnel>> GetRelevantPersonnels(ReferansParameter parameter)
        {
            List<RelevantPersonnel> reports = new List<RelevantPersonnel>();
            UltimateResult<List<RelevantPersonnel>> result = new UltimateResult<List<RelevantPersonnel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[relevantPersonnel_GetRelevantPersonnels]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@CompanyRefId", parameter.CompanyId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    RelevantPersonnel revelant = new RelevantPersonnel();
                                    revelant.Id = Convert.ToInt32(read["Id"]);
                                    revelant.UserRefId = Convert.ToInt32(read["UserRefId"]);
                                    revelant.User = UserManager.Instance.GetUser(new User { UserId = revelant.UserRefId }).Data;
                                    revelant.CompanyRefId = Convert.ToInt32(read["CompanyRefId"]);

                                    reports.Add(revelant);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = reports;
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
