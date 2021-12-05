using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class FixLicManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile FixLicManager _instance;
        public static FixLicManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new FixLicManager();
                        }
                    }
                }
                return _instance;
            }

        }


        public UltimateResult<List<FixLic>> GetFixLices(FixLic parameter)
        {
            List<FixLic> fixLics = new List<FixLic>();
            UltimateResult<List<FixLic>> result = new UltimateResult<List<FixLic>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[fixlic_GetFixLices]";

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
                                    FixLic fixLic = new FixLic();
                                    fixLic.Id = Convert.ToInt32(read["id"]);
                                    fixLic.FixtureId = Convert.ToInt32(read["fixtureNo"]);
                                    fixLic.LicanseId = Convert.ToInt32(read["licanceNo"]);

                                    fixLics.Add(fixLic);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = fixLics;
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

        public UltimateResult<List<FixLic>> AddFixLic(FixLic parameter)
        {
            UltimateResult<List<FixLic>> result = new UltimateResult<List<FixLic>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[fixlic_AddFixLic]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@fixtureId", parameter.FixtureId);
                        sqlCommand.Parameters.AddWithValue("@licanseId", parameter.LicanseId);

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

            AddLog(parameter.UserId, "Lisans bir demirbaşa atandı");

            return result;
        }

        public UltimateResult<List<FixLic>> DeleteFixLic(FixLic parameter)
        {
            UltimateResult<List<FixLic>> result = new UltimateResult<List<FixLic>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[fixlic_DeleteFixLic]";

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

            AddLog(parameter.UserId, "Demirbaş Modeli Silindi");

            return result;
        }


    }
}
