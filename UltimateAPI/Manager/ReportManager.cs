using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;

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
                                    Report report = new Report();
                                    report.Id = Convert.ToInt32(read["id"]);
                                    report.UserId = Convert.ToInt32(read["userId"]);
                                    report.ReportDetail = read["reportDetail"].ToString();
                                    report.InsertDate = Convert.ToDateTime(read["insertDate"]);
                                    report.ItemId = Convert.ToInt32(read["itemId"]);
                                    report.ItemType = (ItemType)Convert.ToInt32(read["ItemType"]);
                                    report.ReportSubject = read["reportSubject"].ToString();
                                    report.AssignmentId = Convert.ToInt32(read["assignmentId"]);
                                    report.Statu = Convert.ToInt32(read["deleted"]);
                                    report.Comment = read["comment"].ToString();

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

        public UltimateResult<List<Report>> GetReportsByStatu(ReportStatu reportStatu)
        {
            List<Report> reports = new List<Report>();
            UltimateResult<List<Report>> result = new UltimateResult<List<Report>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[reports_GetReportsByStatu]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@statu", reportStatu);

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
                                    report.ItemType = (ItemType)Convert.ToInt32(read["ItemType"]);
                                    report.ReportSubject = read["reportSubject"].ToString();
                                    report.AssignmentId = Convert.ToInt32(read["assignmentId"]);
                                    report.Statu = Convert.ToInt32(read["deleted"]);
                                    report.Comment = read["comment"].ToString();

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

        public UltimateResult<List<Report>> GetReportedAssetsByCompany(ReferansParameter parameter)
        {
            List<Report> reports = new List<Report>();
            UltimateResult<List<Report>> result = new UltimateResult<List<Report>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[reports_GetReportsByCompany]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    List<Accessory> accessories = AccessoryManager.Instance.GetAccessories().Data;
                    List<Bill> bills = BillManager.Instance.GetBills().Data;
                    List<Component> components = ComponentManager.Instance.GetComponents().Data;
                    List<License> licenses = LicenseManager.Instance.GetLicenses().Data;
                    List<Toner> toners = TonerManager.Instance.GetToners().Data;
                    List<Fixture> fixtures = FixtureManager.Instance.GetFixtures().Data;

                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@CompanyRefId", parameter.RefId);

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
                                    report.ItemType = (ItemType)Convert.ToInt32(read["ItemType"]);
                                    report.ReportSubject = read["reportSubject"].ToString();
                                    report.AssignmentId = Convert.ToInt32(read["assignmentId"]);
                                    report.Statu = Convert.ToInt32(read["deleted"]);
                                    report.Comment = read["comment"].ToString();

                                    if (report.ItemType == ItemType.Accessory)
                                    {
                                        report.AccessoryItem = (accessories.Find(x => x.Id == report.ItemId));
                                    }
                                    else if (report.ItemType == ItemType.Bill)
                                    {
                                        report.BillItem = (bills.Find(x => x.Id == report.ItemId));
                                    }
                                    else if (report.ItemType == ItemType.Companent)
                                    {
                                        report.ComponentItem = (components.Find(x => x.Id == report.ItemId));
                                    }
                                    else if (report.ItemType == ItemType.Fixture)
                                    {
                                        report.FixtureItem = (fixtures.Find(x => x.Id == report.ItemId));
                                    }
                                    else if (report.ItemType == ItemType.Licence)
                                    {
                                        report.LicenceItem = (licenses.Find(x => x.Id == report.ItemId));
                                    }
                                    else if (report.ItemType == ItemType.Toner)
                                    {
                                        report.TonerItem = (toners.Find(x => x.Id == report.ItemId));
                                    }

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

        public UltimateResult<List<Report>> GetPassiveReports()
        {
            List<Report> reports = new List<Report>();
            UltimateResult<List<Report>> result = new UltimateResult<List<Report>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[reports_GetPassiveReport]";

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
                                    Report report = new Report();
                                    report.Id = Convert.ToInt32(read["id"]);
                                    report.UserId = Convert.ToInt32(read["userId"]);
                                    report.ReportDetail = read["reportDetail"].ToString();
                                    report.InsertDate = Convert.ToDateTime(read["insertDate"]);
                                    report.ItemId = Convert.ToInt32(read["itemId"]);
                                    report.ItemType = (ItemType)Convert.ToInt32(read["ItemType"]);
                                    report.ReportSubject = read["reportSubject"].ToString();
                                    report.AssignmentId = Convert.ToInt32(read["assignmentId"]);
                                    report.Statu = Convert.ToInt32(read["deleted"]);
                                    report.Comment = read["comment"].ToString();

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
            string Proc = "[dbo].[reports_AddReport]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@userId", parameter.UserId);
                        sqlCommand.Parameters.AddWithValue("@reportDetail", parameter.ReportDetail);
                        sqlCommand.Parameters.AddWithValue("@insertDate", DateTime.Now);
                        sqlCommand.Parameters.AddWithValue("@itemId", parameter.ItemId);
                        sqlCommand.Parameters.AddWithValue("@ItemType", parameter.ItemType);
                        sqlCommand.Parameters.AddWithValue("@reportSubject", parameter.ReportSubject);

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

            AddLog(parameter.UserId, "Rapor oluşturuldu");

            return result;
        }

        public UltimateResult<List<Report>> UpdateReportStatu(Report parameter)
        {
            UltimateResult<List<Report>> result = new UltimateResult<List<Report>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[reports_UpdateReportStatu]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@status", parameter.Statu);
                        sqlCommand.Parameters.AddWithValue("@comment", parameter.Comment);
                        sqlCommand.Parameters.AddWithValue("@assignmentId", parameter.AssignmentId);

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

            AddLog(parameter.UserId, "Rapor oluşturuldu");

            return result;
        }
    }
}
