using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;

namespace UltimateAPI.Manager
{
    public class TaskManager:BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile TaskManager _instance;
        public static TaskManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new TaskManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Tasks>> GetTasks(Tasks parameter)
        {
            List<Tasks> componentModels = new List<Tasks>();
            UltimateResult<List<Tasks>> result = new UltimateResult<List<Tasks>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[tasks_GetTasks]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.UserId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Tasks task = new Tasks();
                                    task.Id = Convert.ToInt32(read["id"]);
                                    task.UserId = Convert.ToInt32(read["UserId"]);
                                    task.StartDate = Convert.ToDateTime(read["startDate"]);
                                    task.EndDate= Convert.ToDateTime(read["endDate"]);
                                    task.IsActive= (IsActive)Convert.ToInt32(read["isActive"]);
                                    task.TaskDetail = read["task"].ToString();
                                    task.Count = Convert.ToInt32(read["count"]);

                                    componentModels.Add(task);
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
        
        public UltimateResult<List<Tasks>> GetTask(Tasks parameter)
        {
            List<Tasks> componentModels = new List<Tasks>();
            UltimateResult<List<Tasks>> result = new UltimateResult<List<Tasks>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[tasks_GetTask]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    Tasks task = new Tasks();
                                    task.Id = Convert.ToInt32(read["id"]);
                                    task.UserId = Convert.ToInt32(read["UserId"]);
                                    task.StartDate = Convert.ToDateTime(read["startDate"]);
                                    task.EndDate= Convert.ToDateTime(read["endDate"]);
                                    task.IsActive= (IsActive)Convert.ToInt32(read["isActive"]);
                                    task.TaskDetail = read["task"].ToString();
                                    task.Count = Convert.ToInt32(read["count"]);

                                    componentModels.Add(task);
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

        public UltimateResult<List<Tasks>> AddTask(Tasks parameter)
        {
            UltimateResult<List<Tasks>> result = new UltimateResult<List<Tasks>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[tasks_AddTask]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@userId", parameter.UserId);
                        sqlCommand.Parameters.AddWithValue("@startDate", parameter.StartDate);
                        sqlCommand.Parameters.AddWithValue("@endDate", parameter.EndDate);
                        sqlCommand.Parameters.AddWithValue("@task", parameter.TaskDetail);
                        sqlCommand.Parameters.AddWithValue("@count", parameter.Count);
    
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

            AddLog(parameter.UserId, "Task Eklendi");

            return result;
        }

        public UltimateResult<List<Tasks>> UpdateTask(Tasks parameter)
        {
            UltimateResult<List<Tasks>> result = new UltimateResult<List<Tasks>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[tasks_UpdateTask]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@task", parameter.TaskDetail);
                        sqlCommand.Parameters.AddWithValue("@count", parameter.Count);
                        sqlCommand.Parameters.AddWithValue("@startDate", parameter.StartDate);
                        sqlCommand.Parameters.AddWithValue("@endDate", parameter.EndDate);

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

            AddLog(parameter.UserId, "Task Güncellendi");

            return result;
        }

        public UltimateResult<List<Tasks>> DeleteTask(Tasks parameter)
        {
            UltimateResult<List<Tasks>> result = new UltimateResult<List<Tasks>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[tasks_DeleteTask]";

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

            AddLog(parameter.UserId, "Task Silindi");

            return result;
        }
    }
}
