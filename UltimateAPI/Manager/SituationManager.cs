using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class SituationManager:BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile SituationManager _instance;
        public static SituationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SituationManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Situation>> GetSituations()
        {
            List<Situation> situations = new List<Situation>();
            UltimateResult<List<Situation>> result = new UltimateResult<List<Situation>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[situations_GetSituations]";

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
                                    Situation situation = new Situation();
                                    situation.Id = Convert.ToInt32(read["id"]);
                                    situation.Name = read["statusName"].ToString();

                                    situations.Add(situation);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = situations;
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

        public UltimateResult<List<Situation>> AddSituation(Situation parameter)
        {
            UltimateResult<List<Situation>> result = new UltimateResult<List<Situation>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[situations_AddSituation]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@statusName", parameter.Name);

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

            AddLog(parameter.UserId, "Durum Eklendi");

            return result;
        }

        public UltimateResult<List<Situation>> DeleteSituation(Situation parameter)
        {
            UltimateResult<List<Situation>> result = new UltimateResult<List<Situation>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[situations_DeleteSituation]";

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

            AddLog(parameter.UserId, "Durum Silindi");

            return result;
        }

        public UltimateResult<List<Situation>> UpdateSituation(Situation parameter)
        {
            UltimateResult<List<Situation>> result = new UltimateResult<List<Situation>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[situations_UpdateSituation]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@Id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@statusName", parameter.Name);

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

            AddLog(parameter.UserId, "Durum Güncellendi");

            return result;
        }

        public UltimateResult<List<Situation>> GetSituationByCompanyRefId(ReferansParameter parameter)
        {
            List<Situation> situations = new List<Situation>();
            UltimateResult<List<Situation>> result = new UltimateResult<List<Situation>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[situations_GetSituationByCompnayRefId]";

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
                                    Situation situation = new Situation();
                                    situation.Id = Convert.ToInt32(read["id"]);
                                    situation.Name = read["statusName"].ToString();

                                    situations.Add(situation);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = situations;
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
