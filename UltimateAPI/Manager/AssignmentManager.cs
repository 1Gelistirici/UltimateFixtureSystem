using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class AssignmentManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile AssignmentManager _instance;
        public static AssignmentManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AssignmentManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Assignment>> GetAssignments(Assignment parameter)
        {
            List<Assignment> assignments = new List<Assignment>();
            UltimateResult<List<Assignment>> result = new UltimateResult<List<Assignment>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[assignment_GetAssignments]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@userId", parameter.UserId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Assignment assignment = new Assignment();
                                    assignment.Id = Convert.ToInt32(read["id"]);
                                    assignment.UserId = Convert.ToInt32(read["userId"]);
                                    assignment.AppointerId = Convert.ToInt32(read["appointerId"]);
                                    assignment.ItemType = Convert.ToInt32(read["itemType"]);
                                    assignment.InsertDate = Convert.ToDateTime(read["insertDate"]);
                                    assignment.RecallDate = Convert.ToDateTime(read["recallDate"]);

                                    assignments.Add(assignment);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = assignments;
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

        public UltimateResult<List<Assignment>> AddAssignment(Assignment parameter)
        {
            UltimateResult<List<Assignment>> result = new UltimateResult<List<Assignment>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[assignment_AddAssignment]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@userId", parameter.UserId);
                        sqlCommand.Parameters.AddWithValue("@appointerId", parameter.AppointerId);
                        sqlCommand.Parameters.AddWithValue("@itemType", parameter.ItemType);
                        sqlCommand.Parameters.AddWithValue("@itemId", parameter.ItemId);
                        sqlCommand.Parameters.AddWithValue("@insertDate", DateTime.Now);
                        sqlCommand.Parameters.AddWithValue("@recallDate", parameter.RecallDate < DateTime.Now ? DateTime.Now : parameter.RecallDate);
                        sqlCommand.Parameters.AddWithValue("@piece", parameter.Piece);
                        sqlCommand.Parameters.AddWithValue("@isRecall", parameter.IsRecall);

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

            AddLog(parameter.UserId, "Toner eklendi");
            return result;
        }

        public UltimateResult<List<Assignment>> DeleteAssignment(Assignment parameter)
        {
            UltimateResult<List<Assignment>> result = new UltimateResult<List<Assignment>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[assignment_DeleteAssignment]";

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

            AddLog(parameter.UserId, "Fatura Silindi");
            return result;
        }

        public UltimateResult<List<Assignment>> UpdateAssignment(Assignment parameter)
        {
            UltimateResult<List<Assignment>> result = new UltimateResult<List<Assignment>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[assignment_UpdateAssignment]";

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
                        sqlCommand.Parameters.AddWithValue("@appointerId", parameter.AppointerId);
                        sqlCommand.Parameters.AddWithValue("@itemType", parameter.ItemType);
                        sqlCommand.Parameters.AddWithValue("@insertDate", parameter.InsertDate);
                        sqlCommand.Parameters.AddWithValue("@recallDate", parameter.RecallDate);

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

            AddLog(parameter.UserId, "Fatura Güncellendi");
            return result;
        }

    }
}
