using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class UsedTonerManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile UsedTonerManager _instance;
        public static UsedTonerManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UsedTonerManager();
                        }
                    }
                }
                return _instance;
            }

        }


        public UltimateResult<List<UsedToner>> GetUsedToner(UsedToner parameter)
        {
            List<UsedToner> departments = new List<UsedToner>();
            UltimateResult<List<UsedToner>> result = new UltimateResult<List<UsedToner>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[usedToners_GetUsedToner]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@companyId", parameter.CompanyId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    UsedToner department = new UsedToner();
                                    department.Id = Convert.ToInt32(read["id"]);
                                    department.DepartmentNo = Convert.ToInt32(read["DepartmentNo"]);
                                    department.TonerNo = Convert.ToInt32(read["TonerNo"]);
                                    department.Piece = Convert.ToInt32(read["UsedPiece"]);

                                    departments.Add(department);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = departments;
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

        public UltimateResult<List<UsedToner>> GetUsedToners()
        {
            List<UsedToner> departments = new List<UsedToner>();
            UltimateResult<List<UsedToner>> result = new UltimateResult<List<UsedToner>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[usedToners_GetUsedToners]";

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
                                    UsedToner department = new UsedToner();
                                    department.Id = Convert.ToInt32(read["id"]);
                                    department.DepartmentNo = Convert.ToInt32(read["DepartmentNo"]);
                                    department.TonerNo = Convert.ToInt32(read["TonerNo"]);
                                    department.Piece = Convert.ToInt32(read["UsedPiece"]);

                                    departments.Add(department);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = departments;
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

        public UltimateResult<List<UsedToner>> AddUsedToner(UsedToner parameter)
        {
            UltimateResult<List<UsedToner>> result = new UltimateResult<List<UsedToner>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[usedToners_AddUsedToner]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@tonerNo", parameter.TonerNo);
                        sqlCommand.Parameters.AddWithValue("@departmentNo", parameter.DepartmentNo);
                        sqlCommand.Parameters.AddWithValue("@piece", parameter.Piece);

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

            AddLog(parameter.UserId, "Bileşen Eklendi");

            return result;
        }

        public UltimateResult<List<UsedToner>> DeleteUsedToner(UsedToner parameter)
        {
            UltimateResult<List<UsedToner>> result = new UltimateResult<List<UsedToner>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[usedToners_DeleteUsedToner]";

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

            AddLog(parameter.UserId, "Bileşen Silindi");

            return result;
        }

        public UltimateResult<List<UsedToner>> UpdateUsedToner(UsedToner parameter)
        {
            UltimateResult<List<UsedToner>> result = new UltimateResult<List<UsedToner>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[usedToners_UpdateUsedToner]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@tonerNo", parameter.TonerNo);
                        sqlCommand.Parameters.AddWithValue("@departmentNo", parameter.DepartmentNo);
                        sqlCommand.Parameters.AddWithValue("@piece", parameter.Piece);

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

            AddLog(parameter.UserId, "Bileşen Güncellendi");

            return result;
        }
    }
}
