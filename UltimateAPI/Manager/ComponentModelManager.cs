using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class ComponentModelManager:BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile ComponentModelManager _instance;
        public static ComponentModelManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ComponentModelManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<ComponentModel>> GetComponentModels()
        {
            List<ComponentModel> componentModels = new List<ComponentModel>();
            UltimateResult<List<ComponentModel>> result = new UltimateResult<List<ComponentModel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[companentModel_GetCompanentModels]";

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
                                    ComponentModel componentModel = new ComponentModel();
                                    componentModel.Id = Convert.ToInt32(read["id"]);
                                    componentModel.Name = read["modelName"].ToString();

                                    componentModels.Add(componentModel);
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

        public UltimateResult<List<ComponentModel>> AddComponentModel(ComponentModel parameter)
        {
            UltimateResult<List<ComponentModel>> result = new UltimateResult<List<ComponentModel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[companentModel_AddCompanentModel]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
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

            AddLog(parameter.UserId, "Bileşen Eklendi");

            return result;
        }

        public UltimateResult<List<ComponentModel>> DeleteComponentModel(ComponentModel parameter)
        {
            UltimateResult<List<ComponentModel>> result = new UltimateResult<List<ComponentModel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[companentModel_DeleteCompanentModel]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@Id", parameter.Id);

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

        public UltimateResult<List<ComponentModel>> UpdateComponenModel(ComponentModel parameter)
        {
            UltimateResult<List<ComponentModel>> result = new UltimateResult<List<ComponentModel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[companentModel_UpdateCompanentModel]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
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

            AddLog(parameter.UserId, "Bileşen Güncellendi");

            return result;
        }
    }
}
