using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class MenuManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile MenuManager _instance;
        public static MenuManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MenuManager();
                        }
                    }
                }
                return _instance;
            }
        }


        //public UltimateResult<List<Menu>> GetLogs(Menu parameter)
        //{
        //    List<Menu> componentModels = new List<Menu>();
        //    UltimateResult<List<Menu>> result = new UltimateResult<List<Menu>>();
        //    SqlConnection sqlConnection = null;
        //    string Proc = "[dbo].[logs_GetLogs]";

        //    try
        //    {
        //        using (sqlConnection = Global.GetSqlConnection())
        //        {
        //            ConnectionManager.Instance.SqlConnect(sqlConnection);

        //            using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
        //            {
        //                ConnectionManager.Instance.CmdOperations();

        //                User param = new User();
        //                param.UserId = parameter.UserId;
        //                sqlCommand.Parameters.AddWithValue("@company", UserManager.Instance.GetUser(param).Data.Company);

        //                using (SqlDataReader read = sqlCommand.ExecuteReader())
        //                {
        //                    if (read.HasRows)
        //                    {
        //                        while (read.Read())
        //                        {
        //                            Log log = new Log();
        //                            log.Id = Convert.ToInt32(read["id"]);
        //                            log.Detail = read["detail"].ToString();
        //                            log.Icon = read["icon"].ToString();
        //                            log.Time = Convert.ToDateTime(read["time"]);
        //                            log.UserName = read["username"].ToString();
        //                            log.Type = (LogType)Convert.ToInt32(read["logType"]);
        //                            log.IncorrectPassword = read["incorrectPassword"].ToString();
        //                            log.IncorrectUserName = read["incorrectUserName"].ToString();
        //                            log.IncorrectCompany = read["incorrectCompany"].ToString();

        //                            componentModels.Add(log);
        //                        }
        //                    }
        //                    read.Close();
        //                }
        //                sqlCommand.Dispose();
        //                result.Data = componentModels;
        //            }
        //            ConnectionManager.Instance.Dispose(sqlConnection);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ConnectionManager.Instance.Excep(ex, sqlConnection);
        //        result.IsSuccess = false;
        //        return result;
        //    }

        //    return result;
        //}








    }
}
