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


        //public UltimateResult<List<FixLic>> GetFixtureModels()
        //{
        //    List<FixLic> fixtureModels = new List<FixLic>();
        //    UltimateResult<List<FixLic>> result = new UltimateResult<List<FixLic>>();
        //    SqlConnection sqlConnection = null;
        //    string Proc = "[dbo].[fixtureModel_GetFixtureModels]";

        //    try
        //    {
        //        using (sqlConnection = Global.GetSqlConnection())
        //        {
        //            ConnectionManager.Instance.SqlConnect(sqlConnection);

        //            using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
        //            {
        //                ConnectionManager.Instance.CmdOperations();

        //                using (SqlDataReader read = sqlCommand.ExecuteReader())
        //                {
        //                    if (read.HasRows)
        //                    {
        //                        while (read.Read())
        //                        {
        //                            FixLic fixtureModel = new FixLic();
        //                            fixtureModel.Id = Convert.ToInt32(read["id"]);
        //                            fixtureModel.Name = read["modelName"].ToString();

        //                            fixtureModels.Add(fixtureModel);
        //                        }
        //                    }
        //                    read.Close();
        //                }
        //                sqlCommand.Dispose();
        //                result.Data = fixtureModels;
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

        //public UltimateResult<List<FixLic>> DeleteFixtureModel(FixLic parameter)
        //{
        //    UltimateResult<List<FixLic>> result = new UltimateResult<List<FixLic>>();
        //    SqlConnection sqlConnection = null;
        //    string Proc = "[dbo].[fixtureModel_DeleteFixtureModel]";

        //    try
        //    {
        //        using (sqlConnection = Global.GetSqlConnection())
        //        {
        //            ConnectionManager.Instance.SqlConnect(sqlConnection);

        //            using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
        //            {
        //                ConnectionManager.Instance.CmdOperations();

        //                sqlCommand.Parameters.AddWithValue("@id", parameter.Id);

        //                int effectedRow = sqlCommand.ExecuteNonQuery();
        //                result.IsSuccess = effectedRow > 0;
        //                sqlConnection.Close();
        //                sqlCommand.Dispose();

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

        //    AddLog(parameter.UserId, "Demirbaş Modeli Silindi");

        //    return result;
        //}


    }
}
