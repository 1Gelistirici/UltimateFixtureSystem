using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class AccessoryModelManager:BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile AccessoryModelManager _instance;
        public static AccessoryModelManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AccessoryModelManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<AccessoryModel>> GetAccessoryModels()
        {
            List<AccessoryModel> accessoryModels = new List<AccessoryModel>();
            UltimateResult<List<AccessoryModel>> result = new UltimateResult<List<AccessoryModel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[accessoryModel_GetAccessoryModels]";

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
                                    AccessoryModel accessoryModel = new AccessoryModel();
                                    accessoryModel.Id = Convert.ToInt32(read["id"]);
                                    accessoryModel.Name = read["modelName"].ToString();

                                    accessoryModels.Add(accessoryModel);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = accessoryModels;
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

        public UltimateResult<List<AccessoryModel>> GetAccessoryModelByCompanyRefId(ReferansParameter parameter)
        {
            List<AccessoryModel> accessoryModels = new List<AccessoryModel>();
            UltimateResult<List<AccessoryModel>> result = new UltimateResult<List<AccessoryModel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[accessoryModel_GetAccessoryModelByCompanyRefId]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();
                        sqlCommand.Parameters.AddWithValue("@CompanyRefId", parameter.RefId);

                        using (SqlDataReader read = sqlCommand.ExecuteReader())
                        {
                            if (read.HasRows)
                            {
                                while (read.Read())
                                {
                                    AccessoryModel accessoryModel = new AccessoryModel();
                                    accessoryModel.Id = Convert.ToInt32(read["id"]);
                                    accessoryModel.Name = read["modelName"].ToString();

                                    accessoryModels.Add(accessoryModel);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = accessoryModels;
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

        public UltimateResult<List<AccessoryModel>> AddAccessoryModel(AccessoryModel parameter)
        {
            UltimateResult<List<AccessoryModel>> result = new UltimateResult<List<AccessoryModel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[accessoryModel_AddAccessoryModel]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@modelName", parameter.Name);
                        sqlCommand.Parameters.AddWithValue("@CompanyRefId", parameter.CompanyRefId);

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

            AddLog(parameter.UserId, "Aksesuar Modeli Eklendi");

            return result;
        }

        public UltimateResult<List<AccessoryModel>> DeleteAccessoryModel(AccessoryModel parameter)
        {
            UltimateResult<List<AccessoryModel>> result = new UltimateResult<List<AccessoryModel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[accessoryModel_DeleteAccessoryModel]";

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

            AddLog(parameter.UserId, "Aksesuar Modeli Silindi");

            return result;
        }

        public UltimateResult<List<AccessoryModel>> UpdateAccessoryModel(AccessoryModel parameter)
        {
            UltimateResult<List<AccessoryModel>> result = new UltimateResult<List<AccessoryModel>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[accessoryModel_UpdateAccessoryModel]";

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
                        sqlCommand.Parameters.AddWithValue("@CompanyRefId", parameter.CompanyRefId);

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

            AddLog(parameter.UserId, "Aksesuar Modeli Güncellendi");

            return result;
        }
    }
}
