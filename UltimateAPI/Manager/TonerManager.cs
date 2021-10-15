using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class TonerManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile TonerManager _instance;
        public static TonerManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new TonerManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Toner>> GetToners()
        {
            List<Toner> toners = new List<Toner>();
            UltimateResult<List<Toner>> result = new UltimateResult<List<Toner>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[toners_GetToners]";

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
                                    Toner toner = new Toner();
                                    toner.Id = Convert.ToInt32(read["id"]);
                                    toner.Name = read["name"].ToString();
                                    toner.Piece = Convert.ToInt32(read["piece"]);
                                    toner.Price = Convert.ToInt32(read["price"]);
                                    toner.Boundary = Convert.ToInt32(read["boundary"]);

                                    toners.Add(toner);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = toners;
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

        public UltimateResult<List<Toner>> AddToner(Toner parameter)
        {
            UltimateResult<List<Toner>> result = new UltimateResult<List<Toner>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[toners_AddToner]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@name", parameter.Name);
                        sqlCommand.Parameters.AddWithValue("@piece", parameter.Piece);
                        sqlCommand.Parameters.AddWithValue("@price", parameter.Price);
                        sqlCommand.Parameters.AddWithValue("@boundary", parameter.Boundary);

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

            AddLog(parameter.UserId, "Toner Eklendi");

            return result;
        }

        public UltimateResult<List<Toner>> DeleteToner(Toner parameter)
        {
            UltimateResult<List<Toner>> result = new UltimateResult<List<Toner>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[toners_DeleteToner]";

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

            AddLog(parameter.UserId, "Toner Silindi");

            return result;
        }

        public UltimateResult<List<Toner>> UpdateToner(Toner parameter)
        {
            UltimateResult<List<Toner>> result = new UltimateResult<List<Toner>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[toners_UpdateToner]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@name", parameter.Name);
                        sqlCommand.Parameters.AddWithValue("@piece", parameter.Piece);
                        sqlCommand.Parameters.AddWithValue("@price", parameter.Price);
                        sqlCommand.Parameters.AddWithValue("@boundary", parameter.Boundary);

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

            AddLog(parameter.UserId, "Toner Güncellendi");

            return result;
        }

    }
}
