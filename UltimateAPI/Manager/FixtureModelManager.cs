using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class FixtureModelManager:BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile FixtureModelManager _instance;
        public static FixtureModelManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new FixtureModelManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<FixtureModel>> GetFixtureModels()
        {
            List<FixtureModel> fixtureModels = new List<FixtureModel>();
            UltimateResult<List<FixtureModel>> result = new UltimateResult<List<FixtureModel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[fixtureModel_GetFixtureModels]";

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
                                    FixtureModel fixtureModel = new FixtureModel();
                                    fixtureModel.Id = Convert.ToInt32(read["id"]);
                                    fixtureModel.Name = read["modelName"].ToString();

                                    fixtureModels.Add(fixtureModel);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = fixtureModels;
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

        public UltimateResult<List<FixtureModel>> AddFixtureModel(FixtureModel parameter)
        {
            UltimateResult<List<FixtureModel>> result = new UltimateResult<List<FixtureModel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[fixtureModel_AddFixtureModel]";

            try
            {
                using (sqlConnection = new SqlConnection(@"Data Source=SKY-NET\SQLEXPRESS;Initial Catalog=UDemirbas;Integrated Security=True"))
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@modelName", parameter.Name);

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

            AddLog(parameter.UserId, "Demirbaş Modeli Eklendi");

            return result;
        }

        public UltimateResult<List<FixtureModel>> DeleteFixtureModel(FixtureModel parameter)
        {
            UltimateResult<List<FixtureModel>> result = new UltimateResult<List<FixtureModel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[fixtureModel_DeleteFixtureModel]";

            try
            {
                using (sqlConnection = new SqlConnection(@"Data Source=SKY-NET\SQLEXPRESS;Initial Catalog=UDemirbas;Integrated Security=True"))
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

        public UltimateResult<List<FixtureModel>> UpdateFixtureModel(FixtureModel parameter)
        {
            UltimateResult<List<FixtureModel>> result = new UltimateResult<List<FixtureModel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[fixtureModel_UpdateFixtureModel]";

            try
            {
                using (sqlConnection = new SqlConnection(@"Data Source=SKY-NET\SQLEXPRESS;Initial Catalog=UDemirbas;Integrated Security=True"))
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@Id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@modelName", parameter.Name);

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

            AddLog(parameter.UserId, "Demirbaş Modeli Güncellendi");

            return result;
        }

    }
}
