using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class ReportManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile ReportManager _instance;
        public static ReportManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ReportManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Report>> GetReports()
        {
            List<Report> reports = new List<Report>();
            UltimateResult<List<Report>> result = new UltimateResult<List<Report>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[reports_GetReports]";

            try
            {
                using (sqlConnection = new SqlConnection(@"Data Source=SKY-NET\SQLEXPRESS;Initial Catalog=UDemirbas;Integrated Security=True"))
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
                                    Report report = new Report();
                                    report.Id = Convert.ToInt32(read["id"]);
                                    report.UserId = Convert.ToInt32(read["userId"]);
                                    report.ReportDetail = read["reportDetail"].ToString();
                                    report.InsertDate = Convert.ToDateTime(read["insertDate"]);
                                    report.ItemId = Convert.ToInt32(read["itemId"]);
                                    report.ItemKind = Convert.ToInt32(read["itemKind"]);

                                    reports.Add(report);
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

        public UltimateResult<List<Report>> AddReport(Report parameter)
        {
            UltimateResult<List<Report>> result = new UltimateResult<List<Report>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].reports_AddReport]";

            try
            {
                using (sqlConnection = new SqlConnection(@"Data Source=SKY-NET\SQLEXPRESS;Initial Catalog=UDemirbas;Integrated Security=True"))
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@userId", parameter.UserId);
                        sqlCommand.Parameters.AddWithValue("@reportDetail", parameter.ReportDetail);
                        sqlCommand.Parameters.AddWithValue("@insertDate", parameter.InsertDate);
                        sqlCommand.Parameters.AddWithValue("@itemId", parameter.ItemId);
                        sqlCommand.Parameters.AddWithValue("@itemKind", parameter.ItemKind);

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

            AddLog(parameter.UserId, "Rapor oluşturuldı");

            return result;
        }

    }
}
