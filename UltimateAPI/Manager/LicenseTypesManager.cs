using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class LicenseTypesManager:BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile LicenseTypesManager _instance;
        public static LicenseTypesManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LicenseTypesManager();
                        }
                    }
                }
                return _instance;
            }

        }


        public UltimateResult<List<LicensesType>> GetLicensesTypes()
        {
            List<LicensesType> licensesTypes = new List<LicensesType>();
            UltimateResult<List<LicensesType>> result = new UltimateResult<List<LicensesType>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[licenseType_GetLicenseTypes]";

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
                                    LicensesType licensesType = new LicensesType();
                                    licensesType.Id = Convert.ToInt32(read["id"]);
                                    licensesType.Name = read["licanceTypeName"].ToString();

                                    licensesTypes.Add(licensesType);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = licensesTypes;
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

        public UltimateResult<List<LicensesType>> GetLicensesType(LicensesType parameter)
        {
            List<LicensesType> licensesTypes = new List<LicensesType>();
            UltimateResult<List<LicensesType>> result = new UltimateResult<List<LicensesType>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[licenseType_GetLicenseType]";

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
                                    LicensesType licensesType = new LicensesType();
                                    licensesType.Id = Convert.ToInt32(read["id"]);
                                    licensesType.Name = read["licanceTypeName"].ToString();

                                    licensesTypes.Add(licensesType);
                                }
                            }
                            read.Close();
                        }
                        sqlCommand.Dispose();
                        result.Data = licensesTypes;
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

        public UltimateResult<List<LicensesType>> DeleteLicensesType(LicensesType parameter)
        {
            List<LicensesType> licensesTypes = new List<LicensesType>();
            UltimateResult<List<LicensesType>> result = new UltimateResult<List<LicensesType>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[licenseType_DeleteLicenseType]";

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
            }

            AddLog(parameter.UserId, "Lisans Tipi Silindi");

            return result;
        }

        public UltimateResult<List<LicensesType>> AddLicensesType(LicensesType parameter)
        {
            List<LicensesType> licensesTypes = new List<LicensesType>();
            UltimateResult<List<LicensesType>> result = new UltimateResult<List<LicensesType>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[licenseType_AddLicenseType]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@licenseTypeName", parameter.Name);
               
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

            AddLog(parameter.UserId, "Lisans Tipi Eklendi");

            return result;
        }

        public UltimateResult<List<LicensesType>> UpdateLicenseType(LicensesType parameter)
        {
            List<LicensesType> licensesTypes = new List<LicensesType>();
            UltimateResult<List<LicensesType>> result = new UltimateResult<List<LicensesType>>();
            SqlConnection sqlConnection = null;
            string Proc = "[dbo].[licenseType_UpdateLicenseType]";

            try
            {
                using (sqlConnection = Global.GetSqlConnection())
                {
                    ConnectionManager.Instance.SqlConnect(sqlConnection);

                    using (SqlCommand sqlCommand = ConnectionManager.Instance.Command(Proc, sqlConnection))
                    {
                        ConnectionManager.Instance.CmdOperations();

                        sqlCommand.Parameters.AddWithValue("@id", parameter.Id);
                        sqlCommand.Parameters.AddWithValue("@licenseTypeName", parameter.Name);
                       
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

            AddLog(parameter.UserId, "Lisans Tipi Güncellendi");

            return result;
        }

    }
}
