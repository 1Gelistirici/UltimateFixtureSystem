using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Manager
{
    public class LogManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile LogManager _instance;
        public static LogManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LogManager();
                        }
                    }
                }
                return _instance;
            }

        }


        public UltimateResult<List<Log>> GetLogs(Log parameter)
        {
            List<Log> componentModels = new List<Log>();
            UltimateResult<List<Log>> result = new UltimateResult<List<Log>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[logs_GetLogs]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        User param = new User();
                        param.UserId = parameter.UserId;
                        sqlCommand.Parameters.AddWithValue("@company", UserManager.Instance.GetUser(param).Data[0].Company);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Log log = new Log();
                                    log.Id = Convert.ToInt32(read["id"]);
                                    log.Detail = read["detail"].ToString();
                                    log.Icon = read["icon"].ToString();
                                    log.Time = Convert.ToDateTime(read["time"]);
                                    log.UserName = read["username"].ToString();
                                    log.Type = (LogType)Convert.ToInt32(read["logType"]);

                                    componentModels.Add(log);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = componentModels;
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

        public UltimateResult<List<Log>> AddLog(Log parameter)
        {
            UltimateResult<List<Log>> result = new UltimateResult<List<Log>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[logs_AddLog]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@detail", parameter.Detail);
                        sqlCommand.Parameters.AddWithValue("@icon", parameter.Icon);
                        sqlCommand.Parameters.AddWithValue("@time", parameter.Time);
                        sqlCommand.Parameters.AddWithValue("@userNo", parameter.UserNo);
                        sqlCommand.Parameters.AddWithValue("@logType", parameter.Type);
                        sqlCommand.Parameters.AddWithValue("@incorrectPassword", parameter.IncorrectPassword);
                        sqlCommand.Parameters.AddWithValue("@incorrectUserName", parameter.IncorrectUserName);

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

        public UltimateResult<List<Log>> DeleteLog(Log parameter)
        {
            UltimateResult<List<Log>> result = new UltimateResult<List<Log>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[logs_DeleteLog]";

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
    }
}
