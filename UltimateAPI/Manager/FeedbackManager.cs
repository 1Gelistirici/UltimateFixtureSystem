using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class FeedbackManager
    {
        private static readonly object Lock = new object();
        private static volatile FeedbackManager _instance;
        public static FeedbackManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new FeedbackManager();
                        }
                    }
                }
                return _instance;
            }
        }


        public UltimateSetResult AddFeedback(Feedback parameter)
        {
            UltimateSetResult result = new UltimateSetResult();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[feedback_AddFeedback]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@UserRefId", parameter.UserRefId);
                        sqlCommand.Parameters.AddWithValue("@Title", parameter.Title);
                        sqlCommand.Parameters.AddWithValue("@Comment", parameter.Comment);

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

        public UltimateResult<List<Feedback>> GetFeedbackByUser(ReferansParameter parameter)
        {
            List<Feedback> feedBackList = new List<Feedback>();
            UltimateResult<List<Feedback>> result = new UltimateResult<List<Feedback>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[feedback_GetFeedbackByUser]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@UserRefId", parameter.RefId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Feedback feedback = new Feedback();
                                    feedback.Id = Convert.ToInt32(read["Id"]);
                                    feedback.UserRefId = Convert.ToInt32(read["UserRefId"]);
                                    feedback.Title = Convert.ToString(read["Title"]);
                                    feedback.Comment = Convert.ToString(read["Comment"]);

                                    feedBackList.Add(feedback);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = feedBackList;
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
